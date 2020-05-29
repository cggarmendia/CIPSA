using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CIPSA.M_XI.WebUI.Controllers
{
    public class ShopController : Controller
    {
        #region .: Properties :.
        public IMovieApplicationService _movieApplicationService { get; }
        public IGameApplicationService _gameApplicationService { get; }
        public IClientApplicationService _clientApplicationService { get; }
        public IRentalApplicationService _rentalApplicationService { get; }
        #endregion

        #region .: Constructor :.
        public ShopController(IMovieApplicationService movieApplicationService,
            IGameApplicationService gameApplicationService,
            IClientApplicationService clientApplicationServic,
            IRentalApplicationService rentalApplicationService)
        {
            _movieApplicationService = movieApplicationService;
            _gameApplicationService = gameApplicationService;
            _clientApplicationService = clientApplicationServic;
            _rentalApplicationService = rentalApplicationService;
        }
        #endregion

        #region .: Public Methods :.
        public ActionResult MovieManagement()
        {
            ViewBag.DeviceOptions = GetDeviceOptions();

            return View(Mapper.Map<IEnumerable<MovieDto>, IEnumerable<MovieManagementModel>>(_movieApplicationService.GetAll()));
        }

        public ActionResult GameManagement()
        {
            ViewBag.PlatformOptions = GetPlatformOptions();

            return View(Mapper.Map<IEnumerable<GameDto>, IEnumerable<GameManagementModel>>(_gameApplicationService.GetAll()));
        }

        public ActionResult ClientManagement()
        {
            return View(Mapper.Map<IEnumerable<ClientDto>, IEnumerable<ClientManagementModel>>(_clientApplicationService.GetAll()));
        }

        public ActionResult PendingRentedArticles()
        {
            ViewBag.NIFOptions = GetNIFOptions();
            return View();
        }

        public ActionResult RentedArticles()
        {
            return View(Mapper.Map<IEnumerable<MovieDto>, IEnumerable<RentedArticleModel>>(_movieApplicationService.GetAll()));
        }

        public ActionResult RegisterRental()
        {
            var registerRentalModel = new RegisterRentalModel
            {
                Articles = Mapper.Map<IEnumerable<GameDto>, List<RentedArticleModel>>(_gameApplicationService.GetNonRentedGames()),
                Clients = Mapper.Map<IEnumerable<ClientDto>, List<ClientManagementModel>>(_clientApplicationService.GetAll())
            };
            return View(registerRentalModel);
        }

        public ActionResult ReturnArticle()
        {
            return View();
        }

        public ActionResult LateRental()
        {
            return View( Mapper.Map<IEnumerable<LateRentalDto>, List<RentalModel>>(_rentalApplicationService.GetLateRentals(-4)) );
        }
        #endregion

        #region .: Private Methods :.
        private IEnumerable<SelectListItem> GetDeviceOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Text = "", Value = "" },
                new SelectListItem() { Text = DeviceEnum.BluRay.ToString(), Value = DeviceEnum.BluRay.ToString() },
                new SelectListItem() { Text = DeviceEnum.DVD.ToString(), Value = DeviceEnum.DVD.ToString() }
            };
        }

        private IEnumerable<SelectListItem> GetPlatformOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Text = "", Value = "" },
                new SelectListItem() { Text = PlatformEnum.PS3.ToString(), Value = PlatformEnum.PS3.ToString() },
                new SelectListItem() { Text = PlatformEnum.XBOX360.ToString(), Value = PlatformEnum.XBOX360.ToString() },
                new SelectListItem() { Text = PlatformEnum.WII.ToString(), Value = PlatformEnum.WII.ToString() }
            };
        }

        private IEnumerable<SelectListItem> GetNIFOptions()
        {
            var clientsNif = new List<SelectListItem> {
                new SelectListItem() { Text = "", Value = "" }
            };
            _clientApplicationService.GetClientsNIF().ToList().ForEach(clientNif => clientsNif.Add(new SelectListItem() { Text = clientNif, Value = clientNif }));
            return clientsNif;
        }
        #endregion
    }
}