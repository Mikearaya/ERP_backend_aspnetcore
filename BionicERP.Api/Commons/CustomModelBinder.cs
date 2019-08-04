/*
 * @CreateTime: May 28, 2019 1:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 1:20 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using BionicERP.Commons.QueryHelpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace BionicERP.Api.Commons {
    public class CustomModelBinder : IModelBinder {
        public Task BindModelAsync (ModelBindingContext bindingContext) {
            var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["query"];
            ApiQueryString result = JsonConvert.DeserializeObject<ApiQueryString> (jsonString);

            bindingContext.Result = ModelBindingResult.Success (result);
            return Task.CompletedTask;
        }
    }
}