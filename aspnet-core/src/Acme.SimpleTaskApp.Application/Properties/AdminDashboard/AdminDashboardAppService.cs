using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Acme.SimpleTaskApp.AdminDashboard;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Admin_Dashboard
{
    public class AdminDashboardAppService:IAdminDashboardAppService
    {
        private readonly IRepository<Proje> _projeRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IRepository<ProjeYonetici> _projeYoneticiRepository;
        private readonly IRepository<Musteri> _musteriRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IAbpSession _session;

        public AdminDashboardAppService(IRepository<Proje> projeRepository,
            IRepository<Developer> developerRepository,
            IRepository<ProjeYonetici> projeYoneticiRepository,
            IRepository<Musteri> musteriRepository,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IAbpSession session
            )
        {
            _projeRepository = projeRepository;
            _developerRepository = developerRepository;
            _projeYoneticiRepository = projeYoneticiRepository;
            _musteriRepository = musteriRepository;
            _userManager = userManager;
            _userRepository = userRepository;
            _session = session;
        }

        public async Task<List<ProjeDto>> GetAdminDashboard()
        {
            var userId = _session.UserId;

            var projeEntity = await _projeRepository.GetAll().Include(q=>q.Musteri).Skip(0).Take(10).OrderByDescending(q => q.BaslamaTarihi).ToListAsync();

            return projeEntity.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description = e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                Durum = e.Durum,
                BitisTarihi = e.BitisTarihi,
                MusteriAdi = e.Musteri.MusteriAdi,
            }).ToList();
        }
    }
}
