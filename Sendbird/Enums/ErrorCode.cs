namespace Sendbird.Enums
{
    public enum ErrorCode
    {
        /// <summary>
        /// The request specifies one or more parameters in an unexpected data type. The data type of the parameters should be string.
        /// </summary>
        UnexpectedParameterStringType = 400100,

        /// <summary>
        /// The request specifies one or more parameters in an unexpected data type. The data type of the parameters should be number.
        /// </summary>
        UnexpectedParameterNumberType = 400101,

        /// <summary>
        /// The request specifies one or more parameters in an unexpected data type. The data type of the parameters should be list.
        /// </summary>
        UnexpectedParameterListType = 400102,

        /// <summary>
        /// The request specifies one or more parameters in an unexpected data type. The data type of the parameters should be JSON
        /// </summary>
        UnexpectedParameterJsonType = 400103,

        /// <summary>
        /// The request specifies one or more parameters in an unexpected data type. The data type of the parameters should be boolean
        /// </summary>
        UnexpectedParameterBooleanType = 400104,

        /// <summary>
        /// The request is missing one or more required parameters.
        /// </summary>
        MissingRequiredParameters = 400105,

        /// <summary>
        /// The parameter specifies an invalid negative number. Its value should be a positive number.
        /// </summary>
        NegativeNumberNotAllowed = 400106,

        /// <summary>
        /// The request is not authorized and cannot access the requested resource.
        /// </summary>
        UnauthorizedRequest = 400108,

        /// <summary>
        /// The length of the parameter value is too long.
        /// </summary>
        ParameterValueLengthExceeded = 400110,

        /// <summary>
        /// The request specifies an invalid value.
        /// </summary>
        InvalidValue = 400111,

        /// <summary>
        /// The two parameters of the request, which should have unique values, specify the same value.
        /// </summary>
        IncompatibleValues = 400112,

        /// <summary>
        /// The request specifies one or more parameters which are outside the allowed value range.
        /// </summary>
        ParameterValueOutOfRange = 400113,

        /// <summary>
        /// The resource identified with the URL in the request cannot be found.
        /// </summary>
        InvalidURLOfResource = 400114,

        /// <summary>
        /// The request specifies an illegal value containing special character, empty string, or white space.
        /// </summary>
        NotAllowedCharacter = 400151,

        /// <summary>
        /// The resource identified with the request's resourceId parameter cannot be found.
        /// </summary>
        ResourceNotFound = 400201,

        /// <summary>
        /// The resource identified with the request's resourceId parameter already exists.
        /// </summary>
        ResouceAlreadyExists = 400202,

        /// <summary>
        /// The parameter specifies more items than allowed.
        /// </summary>
        TooManyItemsInParameter = 400203,

        /// <summary>
        /// The request cannot retrieve the deactivated user data.
        /// </summary>
        DeactivatedUserNotAccessible = 400300,

        /// <summary>
        /// The user identified with the request's userId parameter cannot be found.
        /// </summary>
        UserNotFound = 400301,

        /// <summary>
        /// The access token provided for the request specifies an invalid value.
        /// </summary>
        InvalidAccessToken = 400302,

        /// <summary>
        /// The session key provided for the request specifies an invalid value.
        /// </summary>
        InvalidSessionKeyValue = 400303,

        /// <summary>
        /// The application identified with the request cannot be found.
        /// </summary>
        ApplicationNotFound = 400304,

        /// <summary>
        /// The length of the userId parameter value is too long.
        /// </summary>
        UserIdLengthExceeded = 400305,

        /// <summary>
        /// The request cannot be completed because you have exceeded your paid quota.
        /// </summary>
        PaidQuotaExceeded = 400306,

        /// <summary>
        /// The request cannot be completed because it came from the restricted domain.
        /// </summary>
        DomainNotAllowed = 400307,

        /// <summary>
        /// The API token provided for the request specifies an invalid value.
        /// </summary>
        InvalidApiToken = 400401,

        /// <summary>
        /// The request is missing one or more necessary parameters.
        /// </summary>
        MissingSomeParameters = 400402,

        /// <summary>
        /// The request body is an invalid JSON.
        /// </summary>
        InvalidJsonRequestBody = 400403,

        /// <summary>
        /// The request specifies an invalid HTTP request URL that cannot be accessed.
        /// </summary>
        InvalidRequestURL = 400404,

        /// <summary>
        /// The number of the user's websocket connections exceeds the allowed amount.
        /// </summary>
        TooManyUserWebsocketConnections = 400500,

        /// <summary>
        /// The number of the application's websocket connections exceeds the allowed amount.
        /// </summary>
        TooManyApplicationWebsocketConnections = 400501,

        /// <summary>
        /// The request cannot be completed because the blocked user is trying to send a message to the blocking user.
        /// </summary>
        BlockedUserSendNotAllowed = 400700,

        /// <summary>
        /// The request cannot be completed because the blocking user is trying to invite the blocked user to a channel.
        /// </summary>
        BlockedUserInvitedNotAllowed = 400701,

        /// <summary>
        /// The request cannot be completed because the blocked user is trying to invite the blocking user to a channel.
        /// </summary>
        BlockedUserInviteNotAllowed = 400702,

        /// <summary>
        /// The request cannot be completed because the user is trying to enter a banned channel.
        /// </summary>
        BannedUserEnterChannelNotAllowed = 400750,

        /// <summary>
        /// The request cannot be completed because the user is trying to enter a banned custom type channel.
        /// </summary>
        BannedUserEnterCustomChannelNotAllowed = 400751,

        /// <summary>
        /// The request failed because the combination of parameter values is invalid. Even if each parameter value is valid, a combination of parameter values becomes invalid when it doesn't follow specific conditions
        /// </summary>
        InvalidCombinationOfParameterValues = 400920,

        /// <summary>
        /// The request failed because it is sent to an invalid endpoint that no longer exists.
        /// </summary>
        InvalidEndpoint = 400930,

        /// <summary>
        /// The application identified with the request is not available.
        /// </summary>
        ApplicationNotAvailable = 403100,

        /// <summary>
        /// he request cannot be completed because you have exceeded your rate limits.
        /// </summary>
        RateLimitExceeded = 500910,

        /// <summary>
        /// The server encounters an error while trying to register the user's push token. Please retry the request.
        /// </summary>
        InternalErrorPushTokenNotRegistered = 500601,

        /// <summary>
        /// The server encounters an error while trying to unregister the user's push token. Please retry the request.
        /// </summary>
        InternalErrorPushTokenNotUnregistered = 500602,

        /// <summary>
        /// The server encounters an unexpected exception while trying to process the request. Please retry the request.
        /// </summary>
        InternalError = 500901,

        /// <summary>
        /// The request failed due to a temporary failure of the server. Please retry the request.
        /// </summary>
        ServiceUnavailable = 0,
    }
}
