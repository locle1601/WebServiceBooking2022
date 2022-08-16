using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBooking.Backend.wwwroot.assets
{
    public class Swaggerinit
    {
        function createSwaggerUi() {
        var full = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '');

        const ui = SwaggerUIBundle({
            url: full + "/swagger/v2/swagger.json",
            dom_id: '#swagger-ui',
            deepLinking: true,
            presets: [
                SwaggerUIBundle.presets.apis,
                SwaggerUIStandalonePreset
            ],
            plugins: [
                SwaggerUIBundle.plugins.DownloadUrl
            ],
            layout: "StandaloneLayout",

            oauth2RedirectUrl: full + "/oauth2-redirect.html"
        })

        window.ui = ui;
    }

    window.addEventListener("load", function () {
        createSwaggerUi();
    });
    }
}
