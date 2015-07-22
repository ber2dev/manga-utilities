using System;

namespace Mu.Core.Common.Validation
{
    public static class ArgumentsValidation
    {
        public static void NotNull(object pParameter, string pParameterName)
        {
            if (pParameter != null)
            {
                return;
            }

            throw new ArgumentNullException(pParameterName);
        }

        public static void NotNull(object pParameter)
        {
            NotNull(pParameter, "pParameter");
        }
    }
}
