using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Acme.SimpleTaskApp.YoneticiDashboard.YoneticiDashDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.YoneticiDashboard
{
    public class YoneticiDashboardAppService:IYoneticiDashboardAppService
    {
        private readonly IRepository<Proje> _projeRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IRepository<ProjeYonetici> _projeYoneticiRepository;
        private readonly IRepository<Musteri> _musteriRepository;
        private readonly IRepository<Gorev> _gorevRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<MusteriIstek> _musteriIstekRepository;
        private readonly IAbpSession _session;
        private long _userId;
        

        public YoneticiDashboardAppService(IRepository<Proje> projeRepository,
            IRepository<Developer> developerRepository,
            IRepository<ProjeYonetici> projeYoneticiRepository,
            IRepository<Musteri> musteriRepository,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IAbpSession session,
            IRepository<Gorev> gorevRepository,
            IRepository<MusteriIstek> musteriIstekRepository
            )
        {
            _projeRepository = projeRepository;
            _developerRepository = developerRepository;
            _projeYoneticiRepository = projeYoneticiRepository;
            _musteriRepository = musteriRepository;
            _gorevRepository = gorevRepository;
            _userManager = userManager;
            _userRepository = userRepository;
            _session = session;
            _userId = (long)session.UserId;
            _musteriIstekRepository = musteriIstekRepository;

        }

        public async Task<YoneticiDashDto> GetYoneticiDashboardId()
        {
            //Admin Test
            if (_userId == 1) _userId = 4;

            var yonetici = await _projeYoneticiRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();

            var yoneticiDto = new YoneticiDashDto();
            yoneticiDto.YoneticiId=yonetici.Id;

            return yoneticiDto;
        }

        public async Task<List<ProjeDto>> GetYoneticiDashboardProjeler()
        {
            //Admin Test
            if (_userId == 1) _userId = 4;

            var yoneticiId = await _projeYoneticiRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var projeEntity = await _projeRepository.GetAll().Where(q => q.ProjeYoneticisiId == yoneticiId.Id).Include(q => q.Musteri).Skip(0).Take(10).OrderByDescending(q => q.BaslamaTarihi).ToListAsync();

            return projeEntity.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description = e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                ProjeDurum = e.ProjeDurum,
                BitisTarihi = e.BitisTarihi,
                MusteriAdi = e.Musteri.MusteriAdi,
            }).ToList();
        }

        public async Task<List<GorevDto>> GetYoneticiDashboardGorevler()
        {
            //Admin Test
            if (_userId == 1) _userId = 4;

            var yoneticiId = await _projeYoneticiRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();

            var entity = await _gorevRepository.GetAll().Where(q => q.Developer.Yonetici.Id == yoneticiId.Id).Include(q => q.Developer).Include(q => q.Proje).ThenInclude(q => q.ProjeYoneticisi).ToListAsync();

            
            return entity.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                GorevAciklama = e.GorevAciklama,
                ProjeId = e.ProjeId,
                ProjeAdi = e.Proje.ProjeAdi,
                BaslamaZamani = e.BaslamaZamani,
                BitirmeZamani = e.BitirmeZamani,
                DeveloperId = e.DeveloperId,
                DeveloperName = e.Developer.DeveloperName,
                DeveloperNot = e.DeveloperNot,
                GorevDurum = e.GorevDurum,
            }).ToList();

        }

        public async Task<List<MusteriIstekDto>> GetYoneticiDashboardMusteriTalepler()
        {
            //Admin Test
            if (_userId == 1) _userId = 4;
            var yoneticiId = await _projeYoneticiRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var entity = await _musteriIstekRepository.GetAll().Where(q=>q.proje.ProjeYoneticisiId==yoneticiId.Id).Include(q=>q.proje).Include(q=>q.Musteri).ToListAsync();
 
            return entity.Select(e=>new MusteriIstekDto
            {   
                
                MusteriAdi=e.Musteri.MusteriAdi,
                MusteriIstekId=e.Id,
                MusteriIstek=e.Istek,
                MusteriAciklama=e.Aciklama,
                ProjeId=e.ProjeId,
                ProjeAdi=e.proje.ProjeAdi,
                BaslangicTarih=e.BaslangicTarih,
                BitisTarih=e.BitisTarih,

            }).ToList();
        }



    }
}
