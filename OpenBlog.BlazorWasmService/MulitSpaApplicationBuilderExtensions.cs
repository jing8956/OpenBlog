﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OpenBlog.BlazorWasmService
{
    /// <summary>
    /// Provides extension methods used for configuring an application to
    /// host a client-side Single Page Application (SPA).
    /// </summary>
    public static class MulitSpaApplicationBuilderExtensions
    {
        /// <summary>
        /// Handles all requests from this point in the middleware chain by returning
        /// the default page for the Single Page Application (SPA).
        /// 
        /// This middleware should be placed late in the chain, so that other middleware
        /// for serving static files, MVC actions, etc., takes precedence.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="configuration">
        /// This callback will be invoked so that additional middleware can be registered within
        /// the context of this SPA.
        /// </param>
        public static void UseMulitSpa(this IApplicationBuilder app, Action<IMulitSpaBuilder> configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // Use the options configured in DI (or blank if none was configured). We have to clone it
            // otherwise if you have multiple UseSpa calls, their configurations would interfere with one another.
            var optionsProvider = app.ApplicationServices.GetService<IOptions<MulitSpaOptions>>();
            var options = new MulitSpaOptions(optionsProvider.Value);

            var spaBuilder = new DefaultSpaBuilder(app, options);
            configuration.Invoke(spaBuilder);
            SpaDefaultPageMiddleware.Attach(spaBuilder);
        }
    }
}
