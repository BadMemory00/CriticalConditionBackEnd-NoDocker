﻿namespace CriticalConditionBackend.CriticalConditionExceptions
{
    public enum CriticalConditionExceptionsEnum
    {
        SUPER_USER_ALREADY_EXISTS,
        SUPER_USER_WAS_NOT_CREATED,
        SUPER_USER_EMAIL_OR_PASSWORD_ARE_WRONG,
        TOKEN_IS_EMPTY,
        EMAIL_WAS_NOT_FOUND_IN_TOKEN,
        SUPER_USER_DOES_NOT_EXIST,
        TOKEN_USED_HAS_EXPIED,
        TOKEN_USED_IS_NOT_VALID,
        SUB_USER_ALREADY_EXISTS,
        SUB_USER_WAS_NOT_CREATED,
        SUB_USER_DOES_NOT_EXIST,
        DEVICE_WAS_NOT_FOUND,
        NOT_AUTHORIZED_TO_VIEW_DEVICE,
    }
}
