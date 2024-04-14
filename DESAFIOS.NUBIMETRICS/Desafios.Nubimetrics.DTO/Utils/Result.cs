using Desafios.Nubimetrics.DTO.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.DTO.Utils
{
    public class Result<T>
    {
     
        public IList<T> Entities { get; set; }

        public bool Succeeded { get; set; }

        public int Code { get; set; }

        public string[] Errors { get; set; }

        public Paged Paged { get; set; }


    
        public Result()
        {
            Entities = new List<T>();
            Errors = new string[] { };
        }

        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Entities = new List<T>();
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        internal Result(HttpStatusCode code, IList<T> entities, Paged paged, bool succeeded, IEnumerable<string> errors)
        {
            Code = (int)code;
            Entities = entities;
            Paged = paged;
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        internal Result(int code, IList<T> entities, Paged paged, bool succeeded, IEnumerable<string> errors)
        {
            Code = code;
            Entities = entities;
            Paged = paged;
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

       
        public static Result<T> Success(T entity)
        {
            List<T> entities = new List<T>();
            entities.Add(entity);

            Paged paged = new Paged();
            paged.EntityCount = entities.Count;

            return new Result<T>(HttpStatusCode.OK, entities, paged, true, Array.Empty<string>());
        }

        public static Result<T> Success(IList<T> entities)
        {
            Paged paged = new Paged();
            paged.EntityCount = entities.Count;

            return new Result<T>(HttpStatusCode.OK, entities, paged, true, Array.Empty<string>());
        }

        public static Result<T> Success(IList<T> entities, Paged paged)
        {
            return new Result<T>(HttpStatusCode.OK, entities, paged, true, Array.Empty<string>());
        }

        public static Result<T> Failure(T entity, IEnumerable<string> errors)
        {
            List<T> entities = new List<T>();
            Paged paged = new Paged();
            entities.Add(entity);
            return new Result<T>(HttpStatusCode.BadRequest, entities, paged, false, errors);
        }

        public static Result<T> InternalServerError(T entity, IEnumerable<string> errors)
        {
            List<T> entities = new List<T>();
            Paged paged = new Paged();
            entities.Add(entity);
            return new Result<T>(HttpStatusCode.InternalServerError, entities, paged, false, errors);
        }

        public static Result<T> ServiceUnavailable(T entity, IEnumerable<string> errors)
        {
            List<T> entities = new List<T>();
            Paged paged = new Paged();
            entities.Add(entity);
            return new Result<T>(HttpStatusCode.ServiceUnavailable, entities, paged, false, errors);
        }

        public static Result<T> Failure(IList<T> entities, IEnumerable<string> errors)
        {
            Paged paged = new Paged();
            return new Result<T>(HttpStatusCode.BadRequest, entities, paged, false, errors);
        }

        public static Result<T> InternalServerError(IList<T> entities, IEnumerable<string> errors)
        {
            Paged paged = new Paged();
            return new Result<T>(HttpStatusCode.InternalServerError, entities, paged, false, errors);
        }

        public static Result<T> ServiceUnavailable(IList<T> entities, IEnumerable<string> errors)
        {
            Paged paged = new Paged();
            return new Result<T>(HttpStatusCode.ServiceUnavailable, entities, paged, false, errors);
        }

        public static Result<T> Failure<U>(Result<U> result) where U : IDTO
        {
            List<T> entities = new List<T>();
            Paged paged = new Paged();
            return new Result<T>(result.Code, entities, paged, false, result.Errors);
        }

        public static Result<T> Failure<U>(Result<List<U>> result) where U : IDTO
        {
            List<T> entities = new List<T>();
            Paged paged = new Paged();
            return new Result<T>(result.Code, entities, paged, false, result.Errors);
        }

        public static Result<T> Failure(int code, IEnumerable<string> errors)
        {
            Paged paged = new Paged();
            List<T> entities = new List<T>();
            return new Result<T>(code, entities, paged, false, errors);
        }

    }

}
