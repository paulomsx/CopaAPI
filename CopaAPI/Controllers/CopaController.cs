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

        public HttpResponseMessage Post([FromBody] Usuarios usuario) {

            try
            {
                using (var contexto = new Contexto())
                {
                    string email = usuario.email;
                    string nome = usuario.nome;

                    var query = from a in contexto.usuarios
                                select a;

                    // Checagem do email
                    query = from a in contexto.usuarios
                            where a.email == email
                            select a;

                    if (query.Count() > 0) {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "email já cadastrado");
                    }

                    // Checagem do nome
                    query = from a in contexto.usuarios
                            where a.nome == nome
                            select a;

                    if (query.Count() > 0)                {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "nome do usuário já cadastrado");
                    }

                    //Insere usuário
                    contexto.usuarios.Add(usuario);
                    contexto.SaveChanges();

                    // Pega id do usuario
                    query = from a in contexto.usuarios
                            where a.email == email
                            select a;

                    
                    int id = query.FirstOrDefault().id;
                    
                    return Request.CreateResponse(HttpStatusCode.OK, string.Format("id = {0}",id));

                }
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Erro {0}", 1);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }


        // GET api/copa
        public HttpResponseMessage Get()
        {
            try
            {

                using (var contexto = new Contexto()) {


                    string email = "ovo@gmail.com";

                    var query = contexto.usuarios.Where(a => a.email == email);


                    foreach (var usuario in query)
                    {
                        var nome = usuario.nome;
                    }

                    //var query = from a in contexto.usuarios
                    //            where a.email.Contains(email)
                    //            select a;
                    // var query = contexto.usuarios.Where(a => a.email == email);
                    //List<Usuarios> usu = query.ToList();


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
