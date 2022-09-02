using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Authorization;
using Acme.SimpleTaskApp.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Gorevler
{
    [AbpAuthorize(PermissionNames.Pages_Gorev)]
    public class GorevAppService : IGorevAppService
    {
        private readonly IRepository<Gorev> _repository;
        private readonly IRepository<Proje> _proje;
        private readonly IRepository<GorevDurum> _gorevdurum;

        public GorevAppService(IRepository<Gorev> repository, IRepository<Proje> proje, IRepository<GorevDurum> gorevdurum)
        {
            _repository = repository;
            _proje = proje;
            _gorevdurum = gorevdurum;
        }





        public async Task<List<GorevDto>> GetGorevList()
        {
            var entitylist = await _repository.GetAll().Include(a=>a.Proje).Include(a=>a.Developer).Skip(0).Take(10).ToListAsync();
            return entitylist.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                ProjeAdi = e.Proje.ProjeAdi,
                BaslamaZamani = e.BaslamaZamani,
                DeveloperId = e.DeveloperId,
                DeveloperNot=e.DeveloperNot,
                GorevDurum = e.GorevDurum,
               // DeveloperName=e.Developer.DeveloperName,
            }).ToList();
        }

        public async Task<GorevDto> GetGorevByGorevId(int id)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == id).Include(a => a.Proje).Include(a=>a.Developer).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new UserFriendlyException("Geçersiz Gorev Id");
            }
            var gorev = new GorevDto();

            gorev.DeveloperId = entity.DeveloperId;
            gorev.GorevId = entity.Id;
            gorev.GorevTanimi = entity.GorevTanimi;
            gorev.ProjeId = entity.ProjeId;
            gorev.ProjeAdi = entity.Proje.ProjeAdi;
            gorev.BaslamaZamani = entity.BaslamaZamani;
            gorev.GorevDurum = entity.GorevDurum;
           // gorev.DeveloperName = entity.Developer.DeveloperName;
            
            gorev.DeveloperNot = entity.DeveloperNot; 
            if (entity.DeveloperId == 0 || entity.DeveloperId == null)
            {
                gorev.DeveloperName = "Aktif Developer Yok";
            }
            else
            {
                //gorev.DeveloperName = entity.Developer.DeveloperName;
            }
            
            return gorev;        
        }


        public async Task<List<GorevDto>> GetGorevByProjectId(int projectId)
        {
            if (projectId==0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }

            var entityList = await _repository.GetAll().Where(a=>a.ProjeId==projectId).Include(a=>a.Proje).ToListAsync();



            return entityList.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                GorevAciklama = e.GorevAciklama,
                ProjeId = e.ProjeId,
                BaslamaZamani = e.BaslamaZamani,
                BitirmeZamani = e.BitirmeZamani,
                DeveloperId = e.DeveloperId,
               // DeveloperName = e.Developer.DeveloperName,
                DeveloperNot=e.DeveloperNot,
                GorevDurum = e.GorevDurum,
            }).ToList();

          
        }

        public async Task<List<GorevDto>> GetGorevWithoutDeveloper()
        {
            var entity = await _repository.GetAll().Where(a => a.DeveloperId == null).ToListAsync();
            return entity.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                GorevAciklama = e.GorevAciklama,
                ProjeId = e.ProjeId,
                BaslamaZamani = e.BaslamaZamani,
                BitirmeZamani = e.BitirmeZamani,
                DeveloperId = e.DeveloperId,
                //DeveloperName = e.Developer.DeveloperName,
                DeveloperNot = e.DeveloperNot,
                GorevDurum = e.GorevDurum,
            }).ToList();
        }

        public async Task<List<GorevDto>> GetGorevByDeveloper(int devId)
        {
            var entity = await _repository.GetAll().Where(q => q.DeveloperId == devId).Include(q=>q.Developer).Include(q=>q.Proje).ToListAsync();

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
            //    DeveloperName = e.Developer.DeveloperName,
                DeveloperNot = e.DeveloperNot,
                GorevDurum = e.GorevDurum,
            }).ToList();

        }

        public async Task<List<GorevDto>> GetGorevForYonetici(int yoneticiId)
        {
            var entity=await _repository.GetAll().Where(q=>q.Developer.Yonetici.Id==yoneticiId).Include(q=>q.Developer).Include(q=>q.Proje).ThenInclude(q=>q.ProjeYoneticisi).ToListAsync();

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

        public async Task GorevEkle(GorevEkleDto input)
        {
            if (input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }


            var entity = new Gorev
            {
                ProjeId = input.ProjeId,
                GorevTanimi = input.GorevTanimi,
                GorevAciklama = input.GorevAciklama,

                DeveloperId = input.DeveloperId,
                Durum = input.Durum,
                BaslamaZamani = DateTime.Now,
                BitirmeZamani=DateTime.MinValue
            };
            await _repository.InsertAsync(entity);
        }

        public async Task GorevDurumGuncelle(int id,GorevGuncelleDto input)
        {
            var entity = await _repository.GetAll().Where(q => q.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new UserFriendlyException("Gorev bulunamadı");
            }

            entity.GorevDurum = input.GorevDurum;

            if (input.Durum == DurumEnum.Tamamlandi)
            {
                await GorevBitir(id);
                return;
            }

            await _repository.UpdateAsync(entity);
        }

        public async Task GorevBitir(int id)
        {
            var entity = await _repository.GetAll().Where(q => q.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new UserFriendlyException("Gorev bulunamadı");
            }
            entity.Durum = DurumEnum.Tamamlandi;
            entity.BitirmeZamani = DateTime.Now;
            await _repository.UpdateAsync(entity);

        }

        public async Task GorevGuncelle(GorevGuncelleDto input)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == input.GorevId).FirstOrDefaultAsync();
            if (input.GorevId == 0)
            {
                throw new UserFriendlyException("Geçersiz Görev Id");
            }
            if(entity == null)
            {
                throw new UserFriendlyException("Görev Bulunamadı");
            }

            entity.GorevTanimi = input.GorevTanimi;
            entity.GorevAciklama = input.GorevAciklama;
            entity.GorevDurum = input.GorevDurum;

        }


        public async Task GorevToDeveloper(int id,GorevGuncelleDto input)
        {
            var entity=await _repository.GetAll().Where(a => a.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new UserFriendlyException("Görev Bulunamadı");
            }

            input.DeveloperId = entity.Id;
            await _repository.UpdateAsync(entity);

        }

        public async Task<List<GorevDurumDto>> GetGorevDurumuList()
        {
            var entity = await _gorevdurum.GetAll().Skip(0).Take(10).ToListAsync();
            return entity.Select(e => new GorevDurumDto
            {
                GorevDurumId = e.Id,
                GorevDurumu = e.GorevDurumu,
            }
            ).ToList();
        }
        public async Task GorevDurumuEkle(GorevDurumDto input)
        {
            var entity = new GorevDurum
            {
                GorevDurumu = input.GorevDurumu,
            };
            await _gorevdurum.InsertAsync(entity);
        }
        public async Task DeleteGorevDurum(int id)
        {
            await _gorevdurum.DeleteAsync(id);
        }

        public async Task DeleteGorev(int id)
        {
            await _repository.DeleteAsync(id);
        }

        //public void Deneme(int id)
        //{
        //    var gorev = _repository.Get(id);

        //    var dto = new GorevDto()
        //    {
        //        GorevAdi = gorev.GorevAdi,
        //        Developer = new UserDtoTest()
        //        {
        //            KullanciAdi = gorev.Developer.User.Name
        //        }
        //    };

        //}
    }
}
