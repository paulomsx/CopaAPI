using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaAPI.Models;

namespace CopaAPI.Controllers
{
    public class CopaController : ApiController
    {
        // GET api/copa
        public HttpResponseMessage Get()
        {
            try
            {

                using (var contexto = new Contexto()) {

                    var query = from a in contexto.usuarios
                                where a.email.Contains("zxc")
                                select a;

                    if (query.Count() > 0) {
                        var r = "nao é nulo";
                    }

                    foreach (var usuario in query)
                    {
                        var nome = usuario.nome;
                    }
                    

                }

                //    Contexto contexto = new Contexto();

                //contexto.usuarios.Add(usuario);
                //contexto.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new string[] { "value1", "value2" }); ;

            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não encontrado {0}", 1);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }
    }



    //public HttpResponseMessage Get()
    //{
    //    try
    //    {
    //        Usuarios usuario = new Usuarios();
    //        usuario.nome = "dirce";
    //        usuario.email = "dirce@gmail.com";

    //        Contexto contexto = new Contexto();

    //        contexto.usuarios.Add(usuario);
    //        contexto.SaveChanges();

    //        return Request.CreateResponse(HttpStatusCode.OK, new string[] { "value1", "value2" }); ;

    //    }
    //    catch (KeyNotFoundException)
    //    {
    //        string mensagem = string.Format("Não encontrado {0}", 1);
    //        HttpError error = new HttpError(mensagem);
    //        return Request.CreateResponse(HttpStatusCode.NotFound, error);
    //    }
    //}
//}   

   

}
