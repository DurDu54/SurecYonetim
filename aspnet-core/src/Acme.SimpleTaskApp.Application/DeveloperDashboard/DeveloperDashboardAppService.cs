using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Acme.SimpleTaskApp.DeveloperDashboard.Dto;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.DeveloperDashboard
{
    public class DeveloperDashboardAppService : IDeveloperDashboardAppService
    {
        private readonly IRepository<Proje> _projeRepository;
        private readonly IRepository<Gorev> _gorevRepository;
        private readonly IRepository<Developer> _developerRepository;
        private readonly IAbpSession _session;
        private long _userId;

        public DeveloperDashboardAppService(IRepository<Proje> projeRepository, IRepository<Gorev> gorevRepository,IRepository<Developer> repository, IAbpSession session)
        {
            _projeRepository = projeRepository;
            _gorevRepository = gorevRepository;
            _developerRepository = repository;
            _session = session;
            _userId = (long)session.UserId;
        }
        public async Task<DeveloperDashDto> GetDeveloperDashboardId()
        {
            if (_userId == 1) _userId = 4;
            var developer = await _developerRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            
            var developerDto = new DeveloperDashDto();
            
            developerDto.DeveloperId = developer.Id;
            return developerDto;
        }
        public async Task<List<GorevDto>> GetDeveloperDashboardGorevler()
        {
            if (_userId == 1) _userId = 4;
            var developerId = await _developerRepository.GetAll().Where(q => q.UserId == _userId).FirstOrDefaultAsync();
            var gorevEntity = await _gorevRepository.GetAll().Where(q => q.DeveloperId == developerId.Id).ToListAsync();
            return gorevEntity.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi=e.GorevTanimi,
                GorevAciklama = e.GorevAciklama,
                GorevDurum = e.GorevDurum,
                DeveloperName = e.DeveloperName,
                BaslamaZamani = e.BaslamaZamani,
                BitirmeZamani = e.BitirmeZamani,
                DeveloperNot = e.DeveloperNot,
            }).ToList();
        }

        public async Task<List<ProjeDto>> GetDeveloperDashboardProjeler()
        {
            if (_userId==1) _userId = 4;
            
            
            if (!_session.UserId.HasValue)
            {
                throw new UserFriendlyException("Kullanici Girişi Yapılmamış");
            }
            var ls = await _projeRepository.GetAll()
                  .Where(a => a.Developerlar.Any(d => d.UserId==_userId ))
                  .ToListAsync();
            return ls.Select(d => new ProjeDto
            {
                ProjeAdi=d.ProjeAdi,
                BaslamaTarihi = d.BaslamaTarihi,
                BitisTarihi = d.BitisTarihi,
                Description =d.Description,
            }).ToList();
        }

    }
}
