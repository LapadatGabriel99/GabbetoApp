﻿using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// The response for all  Web API calls made
    ///</sumary>
    public class ApiResponse<T>
    {
        #region Public Properties

        /// <summary>
        /// Indicates if the API call was successful
        /// </summary>
        public bool Successful => ErrorMessage == null;

        /// <summary>
        /// The error message for a API call
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The API response object
        /// </summary>
        public T Response { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public ApiResponse()
        {

        }

        #endregion
    }

    /// <summary>
    /// A non generic for a <see cref="ApiResponse{T}"/> in case we don't want to return
    /// an actual inner response
    /// </summary>
    public class ApiResponse
    {
        #region Public Properties

        /// <summary>
        /// Indicates if the API call was successful
        /// </summary>
        public bool Successful => ErrorMessage == null;

        /// <summary>
        /// The error message for a API call
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public ApiResponse()
        {

        }

        #endregion
    }
}
