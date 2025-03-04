using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Pages.Users.Jorson;
using Client.Services.Jorson;
using Client.Models.Jorson;

namespace Client.Pages.Users.Dabby.RamenBlog
{
    internal class IndexBase : PageBase {}

    public partial class Index : IDisposable
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new IndexBase();
        }
        #endregion

        #region Constants
        public const string UserId = "dabby";
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                _base.Initialize();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _blogService.UserId = UserId;
            _blogs = await _blogService.GetAsync();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IEnumerable<Blog> _blogs { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
        private bool _isDisposed { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
            {
                return;
            }
            _base.Dispose();
        }
        #endregion
    }
}
