using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.ListingServices
{
    public class ListProjeApplicationService : IListProjeAppplicationService
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
        private string _roleNames;

        public ListProjeApplicationService
            (
            IRepository<Proje> projeRepository,
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
        public async Task<List<User>> ListProje()
        {
            var roles = _userManager.GetRolesAsync;
            var Name = await _userManager.GetUsersInRoleAsync("Developer");
            List<User> list = new List<User>();
            foreach (var item in Name)
            {
                list.Add(item);
            }
            return list;
        }



    }


    // ilk önce giriş yapan kulanıcının ID si alınacak ve
    // o ID den Kullanıcının Rolü bulunacak
    //Rolü x Olan LİstX E gidecek
}
