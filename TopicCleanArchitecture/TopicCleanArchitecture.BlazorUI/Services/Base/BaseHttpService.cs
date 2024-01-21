﻿using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace TopicCleanArchitecture.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;
        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex) {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() {Message="Invalid Data was submitted",ValidationErrors=ex.Response,Success=false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "the record was not found", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "something went wrong, please try again later.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");
        }
    }
}
