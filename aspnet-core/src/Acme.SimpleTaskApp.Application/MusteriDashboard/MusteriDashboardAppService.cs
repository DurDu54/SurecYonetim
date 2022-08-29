using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Acme.SimpleTaskApp.MusteriDashboard.Dto;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos;
using Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Acme.SimpleTaskApp.YoneticiDashboard.YoneticiDashDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.MusteriDashboard
{
    public class MusteriDashboardAppService : IMusteriDashboardAppService
    {
        private readonly IRepository<Proje> _projeRepository;
        private readonly IRepository<Musteri> _musteriRepository;
        private readonly IRepository<MusteriIstek> _musteriIstekRepository;
        private readonly IAbpSession _session;
        private long _userId;


        public MusteriDashboardAppService(IRepository<Musteri> musteriRepository,
            IRepository<MusteriIstek> musteriIstekRepository,
            IRepository<Proje> projeRepository,
            IAbpSession session)
        {
            _musteriRepository = musteriRepository;
            _musteriIstekRepository = musteriIstekRepository;
            _projeRepository = projeRepository;
            _session = session;
            _userId = (long)session.UserId;
        }
        public async Task<MusteriDashDto> GetMusteriDashboardId()
        {
            //Admin Test
            if (_userId == 1) _userId = 3;

            var musteri = await _musteriRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();

            var musteriDto = new MusteriDashDto();
            musteriDto.MusteriId = musteri.Id;

            return musteriDto;
        }

        public async Task<List<ProjeDto>> GetMusteriDashboardProjeler()
        {
            if (_userId == 1) _userId = 3;
            var musteriId = await _musteriRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var projeEntity = await _projeRepository.GetAll().Where(q => q.MusteriId == musteriId.Id).Include(q => q.Musteri).Skip(0).Take(10).OrderByDescending(q => q.BaslamaTarihi).ToListAsync();
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

        public async Task<List<MusteriIstekDto>> GetMusteriDashboardMusteriTalepler()
        {
            if (_userId == 1) _userId = 3;
            var musteriId = await _musteriRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var entity = await _musteriIstekRepository.GetAll().Where(q => q.MusteriId == musteriId.Id).Include(q => q.proje).Include(q => q.Musteri).ToListAsync();
            return entity.Select(e => new MusteriIstekDto
            {
                MusteriAdi = e.Musteri.MusteriAdi,
                MusteriIstekId = e.Id,
                MusteriIstek = e.Istek,
                MusteriAciklama = e.Aciklama,
                ProjeId = e.ProjeId,
                ProjeAdi = e.proje.ProjeAdi,
                BaslangicTarih = e.BaslangicTarih,
                BitisTarih = e.BitisTarih,
            }).ToList();
        }

        public async Task<List<MusteriDto>> GetMusteriDashboardMusteriBilgileri()
        {
            if (_userId == 1) _userId = 3;
            var musteriId = await _musteriRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var entity = await _musteriRepository.GetAll().Where(q => q.Id == musteriId.Id).ToListAsync();

            return entity.Select(e => new MusteriDto
            {
                MusteriId = e.Id,
                MusteriAdi = e.MusteriAdi,
                Iletisim = e.Iletisim,
                Aciklama = e.Aciklama
            }).ToList();
        }
    }
}
