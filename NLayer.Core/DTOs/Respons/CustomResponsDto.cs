using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Respons
{
    public class CustomResponsDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }


        public static CustomResponsDto<T> Success(int statusCode, T data)
        {
            return new CustomResponsDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponsDto<T> Success(int statusCode)
        {
            return new CustomResponsDto<T> { StatusCode = statusCode};
        }

        public static CustomResponsDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponsDto<T> { StatusCode = statusCode, Errors=errors };
        }

        public static CustomResponsDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponsDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
