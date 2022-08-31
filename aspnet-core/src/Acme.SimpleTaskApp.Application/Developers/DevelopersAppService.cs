using Abp.Authorization;
using Abp.Domain.Repositories;
using Acme.SimpleTaskApp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Developers.DevelopersDto;
using Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto.DevelopersDto;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Authorization.Roles;

namespace Acme.SimpleTaskApp.Projeler.Developers
{
    [AbpAuthorize(PermissionNames.Pages_Developer)]
    public class DevelopersAppService : IDevelopersAppService
    {
        private readonly IRepository<Developer> _repository;
        private readonly IRepository<Gorev> _gorevRepository;
        private readonly IRepository<ProjeYonetici> _yoneticiRepository;
        private readonly IRepository<Proje> _projeRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<DeveloperAlan> _developeralanrepository;
        public DevelopersAppService(IRepository<Developer> repository,
            IRepository<DeveloperAlan> developeralanRepository,
            IRepository<Gorev> gorevRepository,
            IRepository<ProjeYonetici> yoneticiRepository,
            IRepository<Proje> projeRepository,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IRepository<Role> roles)
        {
            _repository = repository;
            _gorevRepository = gorevRepository;
            _yoneticiRepository = yoneticiRepository;
            _projeRepository = projeRepository;
            _userManager = userManager;
            _userRepository = userRepository;
            _roleRepository = roles;
            _developeralanrepository = developeralanRepository;
        }

        public async Task<List<DeveloperDto>> GetDeveloperList()
        {
            var entity = await _repository.GetAll().Include(a => a.User).Include(q => q.Projeler).Skip(0).Take(10).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperId = e.Id,
                Username = e.User.UserName,
                ProjeId = e.ProjeId,
                DeveloperName = e.DeveloperName,
                DeveloperSide = e.DeveloperSide,
                DeveloperCommits = e.DeveloperCommits,
                Projeler = e.Projeler.Select(p => new DeveloperProjectsDto
                {
                    Adi = p.ProjeAdi,
                    ProjectId = p.Id
                }).ToList(),
                ProjeAdlari = e.Projeler.Select(p => p.ProjeAdi).ToList(),
            }
            ).ToList();
        }

        public async Task<List<DeveloperAlanDto>> GetDeveloperAlaniList()
        {
            var entity = await _developeralanrepository.GetAll().Skip(0).Take(10).ToListAsync();
            return entity.Select(e => new DeveloperAlanDto
            {
                DeveloperAlanId = e.Id,
                DeveloperAlani = e.DeveloperAlani,
            }
            ).ToList();
        }

        public async Task<DeveloperDto> GetDeveloperByUserId(long id)
        {
            var entity = await _repository.GetAll().Where(a => a.UserId == id).Include(a => a.Projeler).Include(a => a.User).FirstOrDefaultAsync();
            DeveloperDto developer = new DeveloperDto();

            if (entity != null)
            {
                developer.DeveloperName = entity.DeveloperName;
                developer.UserId = entity.UserId;
                developer.Username = entity.User.UserName;
                developer.ProjeId = entity.ProjeId;
                developer.ProjeAdlari = entity.Projeler.Select(p => p.ProjeAdi).ToList();
                developer.DeveloperCommits = entity.DeveloperCommits;
                developer.DeveloperSide = entity.DeveloperSide;
                developer.YoneticiId = entity.YoneticiId;
                if (developer.ProjeId == null || developer.ProjeId == 0)
                {
                    developer.ProjeId = 0;
                    developer.ProjeAdi = "Proje Yok";
                }

                if (developer.YoneticiId == null || developer.YoneticiId == 0)
                {
                    developer.YoneticiId = 0;
                    developer.YoneticiAdi = "Yonetici Yok";
                }
                return developer;
            }

            else if (entity == null)
            {
                throw new UserFriendlyException("Developer bulunamadı");
            }
            return developer;




        }
        public async Task<DeveloperDto> GetDeveloperByDeveloperId(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == id).Include(a => a.Projeler).Include(a => a.Yonetici).Include(a => a.User).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new UserFriendlyException("Developer Bulunamadı");
            }

            DeveloperDto developer = new DeveloperDto();
            developer.DeveloperName = entity.DeveloperName;
            developer.UserId = entity.UserId;
            developer.Username = entity.User.UserName;

            developer.DeveloperCommits = entity.DeveloperCommits;
            developer.DeveloperSide = entity.DeveloperSide;

            if (entity.ProjeId == null || entity.ProjeId == 0)
            {
                developer.ProjeId = 0;
                developer.ProjeAdi = "Proje Yok";
            }
            else if (entity.ProjeId != null && entity.ProjeId > 0)
            {
                developer.Projeler = entity.Projeler.Select(p => new DeveloperProjectsDto
                {
                    Adi = p.ProjeAdi,
                    ProjectId = p.Id
                }).ToList();
                //developer.ProjeAdi = entity.Projeler.ProjeAdi;
            }

            if (entity.YoneticiId == null || entity.YoneticiId == 0)
            {
                developer.YoneticiId = 0;
                developer.YoneticiAdi = "Yonetici Yok";
            }
            else if (entity.YoneticiId != null && entity.YoneticiId > 0)
            {
                developer.YoneticiId = entity.YoneticiId;
                developer.YoneticiAdi = entity.Yonetici.ProjeYoneticisiAdi;
            }

            return developer;
        }

        public async Task<List<DeveloperDto>> GetDeveloperByYoneticiId(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.YoneticiId == id).Include(a => a.Projeler).Include(q => q.User)
                .Include(a => a.Yonetici).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperId = e.Id,
                Username = e.User.UserName,
                ProjeId = e.ProjeId,
                DeveloperName = e.DeveloperName,
                DeveloperSide = e.DeveloperSide,
                DeveloperCommits = e.DeveloperCommits,
                YoneticiId = e.YoneticiId,
                YoneticiAdi = e.Yonetici.ProjeYoneticisiAdi,
                Projeler = e.Projeler.Select(p => new DeveloperProjectsDto
                {
                    Adi = p.ProjeAdi,
                    ProjectId = p.Id
                }).ToList(),
                ProjeAdlari = e.Projeler.Select(p => p.ProjeAdi).ToList(),
            }).ToList();
        }

        public async Task<List<DeveloperDto>> GetDeveloperByProjeId(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.ProjeId == id).Include(a => a.Projeler).Include(q => q.User)
                .Include(a => a.Yonetici).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperId = e.Id,
                Username = e.User.UserName,
                DeveloperName = e.DeveloperName,
                DeveloperSide = e.DeveloperSide,
                DeveloperCommits = e.DeveloperCommits,
                Projeler = e.Projeler.Select(p => new DeveloperProjectsDto
                {
                    Adi = p.ProjeAdi,
                    ProjectId = p.Id
                }).ToList(),
                YoneticiAdi = e.Yonetici.ProjeYoneticisiAdi,
                YoneticiId = e.YoneticiId,
            }).ToList();
        }

        public async Task<List<DeveloperDto>> GetDeveloperWithoutYonetici()
        {
            var entity = await _repository.GetAll().Where(a => a.YoneticiId == null).Include(a => a.Projeler).Include(q => q.User)
                .Include(a => a.Yonetici).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperId = e.Id,
                Username = e.User.UserName,
                DeveloperName = e.DeveloperName,
                DeveloperSide = e.DeveloperSide,
                DeveloperCommits = e.DeveloperCommits,
                Projeler = e.Projeler.Select(p => new DeveloperProjectsDto
                {
                    Adi = p.ProjeAdi,
                    ProjectId = p.Id
                }).ToList(),
                //ProjeAdi=e.Proje.ProjeAdi,
                YoneticiId = e.YoneticiId,
                //YoneticiAdi=e.Yonetici.ProjeYoneticisiAdi,
            }).ToList();
        }

        public async Task<List<DeveloperDto>> GetDeveloperWithoutProje(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.YoneticiId == id).Include(a => a.Projeler).Include(a => a.User).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperId = e.Id,
                Username = e.User.UserName,
                DeveloperName = e.DeveloperName,
                DeveloperSide = e.DeveloperSide,
                DeveloperCommits = e.DeveloperCommits,
                Projeler = e.Projeler.Select(p => new DeveloperProjectsDto
                    {
                        Adi = p.ProjeAdi,
                        ProjectId = p.Id
                    }).ToList(),
            }).ToList();
        }

        public async Task<List<DeveloperDropDownDto>> GetUserWithoutDeveloper()
        {
            
            var entityUser = await _userManager.GetUsersInRoleAsync("Developer");
            var entity = await _repository.GetAll().Include(q => q.User).ToListAsync();

            var developerList = new List<DeveloperDropDownDto>();
            foreach (var item in entityUser)
            {
                if (!entity.Exists(q => q.UserId == item.Id))
                {
                    developerList.Add(new DeveloperDropDownDto(item.Id, item.Name));
                }
            }
            return developerList;
        }

        public async Task DeveloperEkle(DeveloperEkleDto input)
        {
            var checkId = await _repository.GetAll().Where(a => a.Id == input.DeveloperId).FirstOrDefaultAsync();
            var checkUserId = await _userRepository.FirstOrDefaultAsync(input.UserId);

            if (input.UserId == 0)
            {
                throw new UserFriendlyException("Kullanici seciniz!");
            }
            if (checkId != null)
            {
                throw new UserFriendlyException("Kullanıcı Kayıtlı");
            }
            if (checkUserId == null)
            {
                throw new UserFriendlyException("Geçersiz kullanıcı id");
            }

            var entity = new Developer
            {

                UserId = input.UserId,
                DeveloperName = input.DeveloperAdi,
                DeveloperSide = input.DeveloperSide,
                DeveloperCommits = 0,
            };
            await _repository.InsertAsync(entity);
        }

        public async Task DeveloperAlaniEkle(DeveloperAlanDto input)
        {
            var entity = new DeveloperAlan
            {
                DeveloperAlani = input.DeveloperAlani,
            };
            await _developeralanrepository.InsertAsync(entity);
        }

        public async Task DeveloperGuncelle(int id, DeveloperGuncelleDto input)
        {

            var entity = await _repository.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new UserFriendlyException("Developer bulunamadı");
            }
            if (entity != null)
            {
                if (input.DeveloperAdi == null)
                {
                    input.DeveloperAdi = entity.DeveloperName;
                }
                if (input.DeveloperSide == null)
                {
                    input.DeveloperSide = entity.DeveloperSide;
                }
                entity.DeveloperSide = input.DeveloperSide;
                entity.DeveloperCommits = input.DeveloperCommits;
                await _repository.UpdateAsync(entity);
            }

        }
        public async Task DeveloperBirak(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new UserFriendlyException("Developer Bulunamadı");
            }
            entity.YoneticiId = null;
        }

        public async Task DeveloperYoneticiAtama(int yoneticiId, int developerId)
        {
            var entity = await _repository.GetAll().Where(q => q.Id == developerId).FirstOrDefaultAsync();
            var yoneticiEntity = await _yoneticiRepository.GetAll().Where(q => q.Id == yoneticiId).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new UserFriendlyException("Developer bulunamadı");
            }
            if (yoneticiEntity == null)
            {
                throw new UserFriendlyException("Yönetici bulunamadı");
            }
            else if (yoneticiEntity != null && entity != null)
            {
                entity.YoneticiId = yoneticiEntity.Id;
                await _repository.UpdateAsync(entity);
            }

        }

        public async Task DeveloperProjeAtama(int projeId, int developerId)
        {
            var developer = await _repository.GetAll().Where(q => q.Id == developerId).FirstOrDefaultAsync();
            var proje = await _projeRepository.GetAll().Where(q => q.Id == projeId).FirstOrDefaultAsync();


            developer.Projeler.Add(proje);



            //if (entity == null)
            //{
            //    throw new UserFriendlyException("Developer bulunamadı");
            //}
            //if (projeEntity == null)
            //{
            //    throw new UserFriendlyException("Yönetici bulunamadı");
            //}
            //else if (projeEntity != null && entity != null)
            //{
            //    entity.ProjeId = projeEntity.Id;
            //    await _repository.UpdateAsync(entity);
            //}

        }

        public async Task DeveloperGorevCommit(int gorevId, int devId, DevelopersCommitDto input)
        {
            var gorevEntity = await _gorevRepository.FirstOrDefaultAsync(gorevId);
            var devEntity = await _repository.FirstOrDefaultAsync(devId);

            if (gorevEntity == null)
            {
                throw new UserFriendlyException("Görev Bulunamadı");
            }
            if (devEntity == null)
            {
                throw new UserFriendlyException("Developer Bulunamadı");
            }

            gorevEntity.Durum = input.Durum;
            gorevEntity.BitirmeZamani = input.BitisTarih;
            gorevEntity.DeveloperNot = input.DeveloperNot;
            devEntity.DeveloperCommits = devEntity.DeveloperCommits + 1;
            gorevEntity.DeveloperNot = input.DeveloperNot;
            if (input.BitisTarih == DateTime.MinValue)
            {
                gorevEntity.Durum = DurumEnum.DevamEdiyor;

            }
            else if (input.BitisTarih != DateTime.MinValue)
            {
                gorevEntity.BitirmeZamani = DateTime.MinValue;
                gorevEntity.Durum = DurumEnum.Tamamlandi;
            }

            await _gorevRepository.UpdateAsync(gorevEntity);
            await _repository.UpdateAsync(devEntity);

        }

        public async Task DeleteDeveloper(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task DeleteDeveloperAlani(int id)
        {
            await _developeralanrepository.DeleteAsync(id);
        }
    }
}
