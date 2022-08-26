using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using Acme.SimpleTaskApp.Authorization;
using Acme.SimpleTaskApp.Authorization.Roles;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Musteriler.MusterilerDto;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep;
using Acme.SimpleTaskApp.Roles.Dto;
using Acme.SimpleTaskApp.Users;
using Acme.SimpleTaskApp.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers
{
    [AbpAuthorize(PermissionNames.Pages_Musteri)]
    public class MusteriAppService : IMusteriAppService
    {
        private readonly IRepository<Musteri> _repository;
        private readonly IRepository<MusteriIstek> _istekRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Role> _roleRepository;


        public MusteriAppService(IRepository<Musteri> repository, IRepository<MusteriIstek> istekRepository, UserManager userManager, IRepository<User, long> userRepository,IRepository<Role> roles)
        {
            _repository = repository;
            _istekRepository = istekRepository;
            _userManager = userManager;
            _userRepository = userRepository;
            _roleRepository = roles;
        }



        public async Task<List<MusteriDto>> GetMusteriList()
        {
            var entitylist = await _repository.GetAll().Include(a=>a.User).ToListAsync();
            

            return entitylist.Select(e => new MusteriDto
            {
                MusteriId = e.Id,
                MusteriAdi = e.User.Name,
                Iletisim = e.Iletisim,
                Aciklama = e.Aciklama,
                UserId=e.User.Id,
                Username=e.User.UserName,
            }).ToList();
        }

        public async Task<MusteriDto> GetMusteriById(int musteriId)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == musteriId).Include(a => a.User).FirstOrDefaultAsync();

            return new MusteriDto()
            {
                MusteriId=entity.Id,
                MusteriAdi=entity.MusteriAdi,
                Aciklama = entity.Aciklama,
                Iletisim = entity.Iletisim,
                UserId =entity.User.Id,
                Username = entity.User.UserName,
            };
        }
        
        public async Task<List<MusteriIstekDto>> GetMusteriIstekList()
        {
            var entity = await _istekRepository.GetAll().Include(a => a.proje).Include(a => a.Musteri).ToListAsync();

            return entity.Select(e=>new MusteriIstekDto
            {
                MusteriIstekId = e.Id,
                MusteriAdi = e.Musteri.MusteriAdi,
                MusteriIstek = e.Istek,
                ProjeId = e.ProjeId,
                ProjeAdi = e.proje.ProjeAdi,
                MusteriAciklama = e.Aciklama,
                BaslangicTarih = e.BaslangicTarih,
                BitisTarih = e.BitisTarih,
            }).ToList();
        }

        public async Task<MusteriIstekDto> GetMusteriIstekById(int id)
        {
            var entity = await _istekRepository.GetAll().Where(a => a.Id == id).Include(a=>a.proje).Include(a => a.Musteri).FirstOrDefaultAsync();

            return new MusteriIstekDto()
            {
                MusteriIstekId = entity.Id,
                MusteriAdi=entity.Musteri.MusteriAdi,
                MusteriIstek = entity.Istek,
                ProjeId = entity.ProjeId,
                ProjeAdi=entity.proje.ProjeAdi,
                MusteriAciklama = entity.Aciklama,
                BaslangicTarih = entity.BaslangicTarih,
                BitisTarih = entity.BitisTarih,
            };

        }

        public async Task<List<MusteriIstekDto>> GetMusteriIstekByMusteriId(int id)
        {
            var entity = await _istekRepository.GetAll().Where(q => q.MusteriId == id).Include(q => q.proje).Include(q => q.Musteri).ToListAsync();

            return entity.Select(e => new MusteriIstekDto
            {
                MusteriIstekId = e.Id,
                MusteriAdi = e.Musteri.MusteriAdi,
                MusteriIstek = e.Istek,
                ProjeId = e.ProjeId,
                ProjeAdi = e.proje.ProjeAdi,
                MusteriAciklama = e.Aciklama,
                BaslangicTarih = e.BaslangicTarih,
                BitisTarih = e.BitisTarih,
            }).ToList();
        }

        public async Task MusteriEkle(MusteriEkleDto input)
        {
            var checkId = await _repository.GetAll().Where(q => q.UserId == input.MusteriId).FirstOrDefaultAsync();
            var checkUserId = await _userRepository.FirstOrDefaultAsync(input.UserId);
            if (checkId != null)
            {
                throw new UserFriendlyException("Kullanıcı Kayıtlı!");
            }
            
            if (checkUserId==null)
            {
                throw new UserFriendlyException("Geçersiz kullanıcı id");
            }
            
            
            if (string.IsNullOrEmpty(input.MusteriAdi))
            {
                throw new UserFriendlyException("Müsteri Adı Boş Olamaz");
            }

            var entity = new Musteri
            {
                MusteriAdi = input.MusteriAdi,
                Aciklama = input.Aciklama,
                Iletisim = input.Iletisim,
                UserId = input.UserId,
            };

            await _repository.InsertAsync(entity);
            //  var idCheck = await _repository.GetAll().Include(a => a.User).Where(a => a.Id == input.MusteriId).ToListAsync();

        }

        public async Task<List<MusteriDropDownDto>> GetUserWithoutMusteri()
        {
            var roles = await _roleRepository.GetAll().Where(q => q.NormalizedName == "MUSTERI").FirstOrDefaultAsync();
            var entityUser = await _userManager.GetUsersInRoleAsync("Musteri");
            var entity = await _repository.GetAll().Include(q => q.User).ToListAsync();

            var musteriList = new List<MusteriDropDownDto>();

            foreach(var item in entityUser)
            {
               
                if (!entity.Exists(q => q.UserId == item.Id))
                {
                    musteriList.Add(new MusteriDropDownDto(item.Id, item.Name));
                }
            }

            return musteriList;
        }

        public async Task MusteriGuncelle(MusteriGuncelleDto input,int id)
        {
            //if (!input.CustomerId.HasValue || input.CustomerId == 0)
            //{
            //    throw new System.Exception("Proje Bulunamadı");
            //}
           
            //if (!input.MusteriId.HasValue || input.MusteriId == 0)
            //{
            //    throw new UserFriendlyException("Geçersiz Müşteri Id");
            //}

            var entity = await _repository.FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new UserFriendlyException("Geçersiz Müşteri Id");
            }
            else if (entity !=null)
            {
                if (input.MusteriAdi == null)
                {
                    input.MusteriAdi = entity.MusteriAdi;
                }
                if (input.Aciklama == null)
                {
                    input.Aciklama = entity.Aciklama;
                }
                if(input.Iletisim == null)
                {
                    input.Iletisim = entity.Iletisim;
                }
                entity.MusteriAdi = input.MusteriAdi;
                entity.Aciklama = input.Aciklama;
                entity.Iletisim = input.Iletisim;         

            }

            await _repository.UpdateAsync(entity);
        }

        public async Task MusteriIstekEkle(MusteriIstekEkleDto input)
        {
            if (input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }
            var entity = new MusteriIstek
            {
                MusteriId = input.MusteriId,
                ProjeId=input.ProjeId,
                Istek=input.MusteriTalep,
                Aciklama=input.MusteriAciklama,
                BaslangicTarih = DateTime.Now,

            };

            await _istekRepository.InsertAsync(entity);
        }        

        public async Task MusteriIstekUpdate(int istekId,MusteriIstekDuzenleDto input)
        {
            var entity = await _istekRepository.GetAll().Where(a => a.Id == istekId).FirstOrDefaultAsync();

            var entityUpdate= new MusteriIstek()
            {
                ProjeId=entity.ProjeId,
                MusteriId= entity.MusteriId,
                Aciklama = input.MusteriAciklama,
                Istek = input.MusteriIstek,
                BaslangicTarih = DateTime.Now,               
            };
            await _istekRepository.InsertAsync(entityUpdate);

            await MusteriIstekArsivle(istekId);
            
        }
        public async Task MusteriIstekArsivle(int istekId)
        {
            var entity = await _istekRepository.GetAll().Where(a => a.Id == istekId).FirstOrDefaultAsync();
            entity.DegistirmeTarih= DateTime.Now;
            entity.IsDeleted = true;
            await _istekRepository.UpdateAsync(entity);           

        }

        public async Task DeleteMusteri(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task DeleteIstek(int id)
        {
            await _istekRepository.DeleteAsync(id);
        }
    }
}
