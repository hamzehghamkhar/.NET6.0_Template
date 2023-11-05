using Microsoft.AspNetCore.Identity;

namespace app.DataLayer.Context
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = $"یک خطای ناشناخته رخ داده است."
            };
        }
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code = nameof(ConcurrencyFailure),
                Description = "Optimistic concurrency failure, object has been modified."
            };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = nameof(PasswordMismatch), Description = "رمز عبور نادرست است." };
        }
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = "رمز نامعتبر است."
            };
        }
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = "کاربری با این ورود از قبل موجود است."
            };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = $"نام کاربری {userName} نامعتبر است ، فقط می تواند حاوی حروف یا رقم باشد"
            };
        }
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = $"'{email}'نامعتبر است"
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = "قبلا در سیستم ثبت نام کرده اید.لطفا وارد حساب کاربری خود شوید",
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"پست الکترونکی '{email}' قبلا ثبت شده است"
            };
        }
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = $"'{role}' نامعتبر است"
            };
        }
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = $"نقش '{role}' تکراری است"
            };
        }
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = "کاربر قبلاً یک رمز ورود تنظیم کرده است."
            };
        }
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = "Lockout is not enabled for this user."
            };
        }
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = $"User already in role ."
            };
        }
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = $"User is not in role '{role}'."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $"گذرواژه ها باید حداقل {length} کاراکتر داشته باشند."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "گذرواژه ها باید حداقل یک کاراکتر غیر الفبا داشته باشند."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "گذرواژه ها باید حداقل یک رقم داشته باشند ('0'-'9')."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "گذرواژه ها باید حداقل یک حرف کوچک داشته باشند ('a'-'z')."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "گذرواژه ها باید حداقل یک حرف بزرگ داشته باشند ('A'-'Z')."
            };
        }
    }
}
