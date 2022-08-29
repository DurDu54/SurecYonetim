using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Authorization;
using Acme.SimpleTaskApp.Authorization.Roles;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Yoneticiler.YoneticilerDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Yoneticiler
{
    [AbpAuthorize(PermissionNames.Pages_Yonetici)]
    public class YoneticiAppService :IYoneticiAppService
    {
        private readonly IRepository<ProjeYonetici> _repository;
        private readonly IRepository<Proje> _projeRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public YoneticiAppService(IRepository<ProjeYonetici> repository,
            IRepository<Proje> projeRepository, UserManager userManager,
            IRepository<User, long> userRepository,
            IRepository<Role> roles,
            IRepository<Developer> developerRepository)
        {
            _repository = repository;
            _projeRepository = projeRepository;
            _userManager = userManager;
            _userRepository = userRepository;
            _roleRepository = roles;
            _developerRepository = developerRepository;
        }

        public async Task<List<YoneticiDto>> GetYoneticiList()
        {
            var entity = await _repository.GetAll().Include(a => a.User).Skip(0).Take(10).ToListAsync();
            

            return entity.Select(e => new YoneticiDto
            {
                YoneticiId = e.Id,
                YoneticiName=e.ProjeYoneticisiAdi,
                UserName=e.User.UserName,
                Aciklama=e.Aciklama,
                Iletisim=e.Iletisim,

            }).ToList();
        }

        public async Task<YoneticiDto> GetYoneticiByYoneticiId(int id)
        {
            var entity = await _repository.GetAll().Where(q => q.Id == id).Include(q => q.User).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new UserFriendlyException("Yonetici bulunamadı!");
            }

            var Yonetici = new YoneticiDto();

            Yonetici.YoneticiId = entity.Id;
            Yonetici.UserId = (int)entity.UserId;
            Yonetici.YoneticiName = entity.ProjeYoneticisiAdi;
            Yonetici.UserName=entity.User.UserName;
            Yonetici.Aciklama = entity.Aciklama;
            Yonetici.Iletisim = entity.Iletisim;

            return Yonetici;
        }

        public async Task<List<YoneticiDropDownDto>> GetUserWithoutYonetici()
        {
            var entityUser = await _userManager.GetUsersInRoleAsync("Yonetici");
            var entity = await _repository.GetAll().Include(q => q.User).ToListAsync();

            var yoneticiList = new List<YoneticiDropDownDto>();

            foreach(var item in entityUser)
            {
                if (!entity.Exists(q => q.UserId == item.Id))
                {
                    yoneticiList.Add(new YoneticiDropDownDto(item.Id, item.Name));
                }
            }
            return yoneticiList;
        }

        //public async Task<YoneticiWithProjeDto> GetYoneticiWithProje(int id)
        //{
        //    var entity = await _repository.GetAll().Where(q => q.Id == id).Include(q => q.User).FirstOrDefaultAsync();

        //    var projeEntity = await _projeRepository.GetAll().Where(q => q.ProjeYoneticisiId == id).ToListAsync();

        //    var Yonetici = new YoneticiWithProjeDto();
        //    projeEntity.Select(e => new ProjeDetailsForYonetici
        //    {
        //        ProjeId = e.Id,
        //        ProjeAdi = e.ProjeAdi,
        //         BaslangicTarihi= e.BaslamaTarihi,
        //    }).ToList();

        //    Yonetici.YoneticiId = entity.Id;

        //    Yonetici.YoneticiAdi = entity.User.Name;
        //    Yonetici.UserName = entity.User.UserName;
        //    Yonetici.Aciklama = entity.Aciklama;
        //    Yonetici.Projeler = projeEntity;

        //    return Yonetici;
        //}

        public async Task YoneticiEkle(YoneticiEkleDto input)
        {
            var checkId = await _repository.GetAll().Where(q => q.UserId == input.UserId).FirstOrDefaultAsync();
            var checkUserId = await _userRepository.FirstOrDefaultAsync(input.UserId);

            if (string.IsNullOrEmpty(input.YoneticiAdi))
            {
                throw new UserFriendlyException("Yonetici Adi bos olamaz");
            }

            if (checkUserId == null)
            {
                throw new UserFriendlyException("Kullanıcı bulunamadı");
            }

            if (checkId != null)
            { 
                throw new UserFriendlyException("Kullanıcı bu role sahip");
            }

            var entity = new ProjeYonetici
            {
                ProjeYoneticisiAdi=input.YoneticiAdi,
                UserId=input.UserId,
                Aciklama=input.Aciklama,
                Iletisim=input.Iletisim,
            };

            await _repository.InsertAsync(entity);
        }

        public async Task YoneticiGuncelle(YoneticiGuncelleDto input,int id)
        {
            

            var entity= await _repository.GetAll().Where(a=>a.Id==id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new UserFriendlyException("Geçersiz Yönetici Id");
            }
            if (input.YoneticiAdi==null)
            {
                input.YoneticiAdi = entity.ProjeYoneticisiAdi;
            }
            if (input.Iletisim == null)
            {
                input.Iletisim = entity.Iletisim;
            }
            if(input.Aciklama == null)
            {
                input.Aciklama = entity.Aciklama;
            }
            entity.ProjeYoneticisiAdi = input.YoneticiAdi;
            entity.Aciklama = input.Aciklama;
            entity.Iletisim = input.Iletisim;
            await _repository.UpdateAsync(entity);
        }
        
        public async Task ProjeYoneticiAtama(int yoneticiId,int projeId)
        {
            var entityProje = await _projeRepository.GetAll().Where(q => q.Id == projeId).FirstOrDefaultAsync();
            var entityYonetici = await _repository.GetAll().Where(q => q.Id == yoneticiId).FirstOrDefaultAsync();

            
            if(entityProje== null)
            {
                throw new UserFriendlyException("Proje bulunamadı");
            }
            if (entityYonetici == null)
            {
                throw new UserFriendlyException("Yonetici bulunamadı");
            }
            entityProje.ProjeYoneticisiId = yoneticiId;
            await _projeRepository.UpdateAsync(entityProje);
        }

        public async Task DeveloperYoneticiAtama(int yoneticiId,int devId)
        {
            var entityDeveloper=await _developerRepository.GetAll().Where(q=>q.Id==devId).FirstOrDefaultAsync();
            var entityYonetici = await _repository.GetAll().Where(q => q.Id == yoneticiId).FirstOrDefaultAsync();

            if(entityDeveloper== null)
            {
                throw new UserFriendlyException("Developer Bulunamadı");
            }
            if(entityYonetici == null)
            {
                throw new UserFriendlyException("Yonetici Bulunamadı");
            }
            entityDeveloper.YoneticiId = yoneticiId;
            await _developerRepository.UpdateAsync(entityDeveloper);
        }
        public async Task DeleteYonetici(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
