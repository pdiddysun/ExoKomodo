
using ExoKomodo.Config;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson
{
    public partial class Home : IDisposable
    {
        #region Public

        #region Constructors
        public Home()
        {
            _pageBase = new HomePageBase();
            _pageBase.Initialize();
        }
        #endregion

        #region Constants
        public const string UserId = "jorson";
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _pageBase.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override async Task OnInitializedAsync()
        {
            _self = (await _http.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self == null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        private PageBase _pageBase { get; set; }
        private User _self;
        #endregion

        #region Classes

        private class HomePageBase : PageBase
        {
            #region Public

            #region Member Methods
            public override void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
            #endregion

            #endregion
        }

        #endregion

        #endregion
    }
}