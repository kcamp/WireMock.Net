﻿using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;

[module:
    SuppressMessage("StyleCop.CSharp.DocumentationRules",
        "SA1633:FileMustHaveHeader",
        Justification = "Reviewed. Suppression is OK here, as unknown copyright and company.")]

namespace WireMock
{
    /// <summary>
    /// The http listener response mapper.
    /// </summary>
    public class HttpListenerResponseMapper
    {
        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="responseMessage">
        /// The response.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public void Map(ResponseMessage responseMessage, HttpListenerResponse result)
        {
            result.StatusCode = responseMessage.StatusCode;
            responseMessage.Headers.ToList().ForEach(pair => result.AddHeader(pair.Key, pair.Value));
            if (responseMessage.Body != null)
            {
                var content = Encoding.UTF8.GetBytes(responseMessage.Body);
                result.OutputStream.Write(content, 0, content.Length);
            }
        }
    }
}