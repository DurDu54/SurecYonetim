using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Authorization;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Acme.SimpleTaskApp.Projeler.ProjelerDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Projeler
{
    [AbpAuthorize(PermissionNames.Pages_Proje)]
    public class ProjeAppService : IProjeAppService
    {
        private readonly IRepository<Proje> _repository;
        private readonly IRepository<Musteri> _musteriRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IRepository<ProjeDurum> _projeDurumRepo;
        public ProjeAppService(IRepository<Proje> repository,IRepository<Musteri> musteri,IRepository<Developer> developerRepository,IRepository<ProjeDurum> projedurum
            )
        {
            _repository = repository;
            _musteriRepository = musteri;
            _developerRepository = developerRepository;
            _projeDurumRepo = projedurum;
        }

        

        public async Task<List<ProjeDto>> GetProjeList()
        {
            /*
                  Musterileri repositoryden ayrı olarak çekip musteriListten
                 Musteri bilgilerine ulasabiliriz

                     PS . Yigit
             */
            var getList = await _repository.GetAll().Where(q=>q.IsDone==false).Include(a=>a.Musteri).ThenInclude(a=>a.User).Skip(0).Take(15).ToListAsync();
            var getSingle = getList.FirstOrDefault();
            
            return getList.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description = e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                //Durum = e.Durum,
                ProjeDurum = e.ProjeDurum,
                BitisTarihi = e.BitisTarihi,
                MusteriAdi = e.Musteri.MusteriAdi,
            }).ToList();

        }


        public async Task<List<ProjeDto>> getProjelistDeveloper(int developerId)
        {
            var entity = await _developerRepository.GetAll().Where(q => q.Id == developerId).Include(q => q.Projeler).FirstOrDefaultAsync();
            int id = (int)entity.ProjeId;
            var projem = await _repository.GetAll().Where(q => q.Id == id).Include(q=>q.ProjeYoneticisi).Skip(0).Take(15).ToListAsync();

            return projem.Select(e => new ProjeDto
            {

                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                BaslamaTarihi = e.BaslamaTarihi,
                BitisTarihi = e.BitisTarihi,
                Description = e.Description,
                MusteriAdi="Yöneticiniz : "+e.ProjeYoneticisi.ProjeYoneticisiAdi,
                ProjeDurum = e.ProjeDurum,


            }).ToList();
        }

        //Müşteri için Proje görüntüleme tablosu

        public async Task<List<ProjeDto>> GetProjeListMusteri(int musteriId)
        {
            var entity = await _repository.GetAll().Where(a => a.MusteriId == musteriId).ToListAsync();
            var developerList = new List<Developer>();
            foreach(var item in entity)
            {
                var developerEntity = await _developerRepository.GetAll().Where(a => a.ProjeId == item.Id).ToListAsync();
                developerList.Add(developerEntity.FirstOrDefault());

            }
            if (entity.Count == 0)
            {
                throw new UserFriendlyException("Projeniz bulunmamaktadır");
            }

            return entity.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                BaslamaTarihi = e.BaslamaTarihi,
                BitisTarihi = e.BitisTarihi,
                Developers = developerList,
                MusteriAdi="Benim Projem",
                Description=e.Description,

                ProjeDurum = e.ProjeDurum,

            }).ToList();
        }

        public async Task<List<ProjeDto>> GetProjeListForYonetici(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.ProjeYoneticisiId == id).Include(a=>a.Musteri).ToListAsync();
            var developerList = new List<Developer>();           

            return entity.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description=e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                MusteriAdi= e.Musteri.MusteriAdi,
                ProjeDurum = e.ProjeDurum,

            }).ToList();
        }        
        
        public async Task<ProjeDto> GetProjeById(int projeId)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == projeId).Include(q=>q.Musteri).FirstOrDefaultAsync();

            return new ProjeDto()
            {
                ProjeId = entity.Id,
                ProjeAdi = entity.ProjeAdi,
                Description = entity.Description,
                BaslamaTarihi = entity.BaslamaTarihi,
                BitisTarihi = entity.BitisTarihi,
                ProjeDurum = entity.ProjeDurum,
                MusteriAdi = entity.Musteri.MusteriAdi,
            };
        }

        public async Task<List<ProjeDto>> GetProjeWithoutYonetici()
        {
            var entity = await _repository.GetAll().Where(q => q.ProjeYoneticisiId == null).ToListAsync();
            return entity.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description = e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                ProjeDurum = e.ProjeDurum,
                BitisTarihi = e.BitisTarihi,
               // MusteriAdi = e.Musteri.MusteriAdi,
            }).ToList();

        }


        public async Task<Proje> ProjeEkle(ProjeEkleDto input)
        {
            if (string.IsNullOrEmpty(input.ProjeAdi))
            {
                throw new UserFriendlyException("Proje Adı Boş Olamaz");
            }


            var entity = new Proje
            {
                ProjeAdi = input.ProjeAdi,
                Description = input.Description,
                MusteriId = input.MusteriId,
                BaslamaTarihi = DateTime.Now,
                
            };
            return await _repository.InsertAsync(entity);
        }



        public async Task ProjeGuncelle(ProjeGuncelleDto input,int id)
        {
            var entity = await _repository.GetAsync(input.ProjeId);
            if (input.ProjeId == 0||entity==null)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }
            if (string.IsNullOrEmpty(entity.ProjeAdi))
            {
                throw new UserFriendlyException("Proje Adı Boş Olamaz");
            }
            if (entity.MusteriId == 0)
            {
                throw new UserFriendlyException("Geçersiz Müşteri Id");
            }
            if (input.ProjeAdi == null)
            {
                input.ProjeAdi = entity.ProjeAdi;
            }
            if(input.Description == null)
            {
                input.Description = entity.Description;
            }         
            
            entity.ProjeAdi = input.ProjeAdi;
            entity.Description = input.Description;
            //entity.BitisTarihi = input.BitisTarihi;
            entity.ProjeDurum = input.ProjeDurum;
            //entity.MusteriBitisTarihi = input.MusteriBitisTarihi;
            //entity.ProjeYoneticisiId = input.ProjeYoneticisiId;
            //entity.Description = input.Description;
            //entity.ProjeYoneticisi=input.ProjeYoneticisi;

            await _repository.UpdateAsync(entity);

        }



        //Müşteri Açıklama Güncelleme
        public async Task ProjeGuncelleMusteri(ProjeGuncelleDto input)
        {
         
            
            var entity = await _repository.GetAsync(input.ProjeId);
           
            entity.Description = input.Description;

            await _repository.UpdateAsync(entity);

        }
        public async Task ProjeBırak(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new UserFriendlyException("Proje Bulunamadı");
            }
            entity.ProjeYoneticisiId = null;
        }

        public async Task<List<ProjeDurumDto>> GetProjeDurumuList()
        {
            var entity = await _projeDurumRepo.GetAll().Skip(0).Take(10).ToListAsync();
            return entity.Select(e => new ProjeDurumDto
            {
                ProjeDurumId = e.Id,
                ProjeDurumu = e.ProjeDurumu,
            }
            ).ToList();
        }
        public async Task ProjeDurumuEkle(ProjeDurumDto input)
        {
            var entity = new ProjeDurum
            {
                ProjeDurumu = input.ProjeDurumu,
            };
            await _projeDurumRepo.InsertAsync(entity);
        }

        public async Task DeleteProjeDurum(int id)
        {
            await _projeDurumRepo.DeleteAsync(id);
        }
        public async Task DeleteProje(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
