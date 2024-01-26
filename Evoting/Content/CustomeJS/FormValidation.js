const PhoneNumberdigit = document.querySelectorAll(".PhoneNumber");
const EmailAddressdigit = document.querySelectorAll(".EmailAddress");
const NumberCheckdigit = document.querySelectorAll(".NumberCheck");
const Passworddigit = document.querySelectorAll(".Password");
const DropWondoption = document.querySelectorAll(".DropWond");
const EmailRegexcheck = "/^(([^<>()[\]\\.,;:\s@@\"]+(\.[^<>()[\]\\.,;:\s@@\"]+)*)|(\".+\"))((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/"
const PhoneNumberRegexcheck = "/^(?:(?:\+|00)88|01)?\d{11}$/";
const NIDRegexcheck = "^[0-9]{11}$";
const Passwordregexcheck = "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{4,4}$";
// All Validation Start
EmailAddressdigit.forEach((EmailInput, index) => {
    debugger
    EmailInput.addEventListener("change", () => {
        var Emailvalue = $(".EmailAddress").eq(index).val();
        if (Emailvalue.match(EmailRegexcheck) != true) {
            const ErrorMSG = document.createElement("p");
            ErrorMSG.className = "ErrorMsg";
            ErrorMSG.innerText = "Please Enter Valid Email";
            $(".EmailAddress").eq(index).after(ErrorMSG);
        }
    });
});
Passworddigit.forEach((PasswordInput, index) => {
    debugger
    PasswordInput.addEventListener("change", () => {
        var Passwordvalue = $(".EmailAddress").eq(index).val();
        if (Passwordvalue.match(Passwordregexcheck) != true) {
            const ErrorMSG = document.createElement("p");
            ErrorMSG.className = "ErrorMsg";
            ErrorMSG.innerText = "Password requires one lower case letter, one upper case letter, one digit, 6-13 length, and no spac";
            $(".Password").eq(index).after(ErrorMSG);
        }
    });
});
PhoneNumberdigit.forEach((PhoneNumberInput, index) => {
    debugger
    PhoneNumberInput.addEventListener("change", () => {
        var PhoneNumbervalue = $(".PhoneNumber").eq(index).value;
        if (PhoneNumbervalue.match(PhoneNumberRegexcheck) != true) {
            const ErrorMSG = document.createElement("p");
            ErrorMSG.className = "ErrorMsg";
            ErrorMSG.innerText = "Please Enter Valid Phone Number";
            $(".PhoneNumber").eq(index).after(ErrorMSG);
        }
    });
});
NumberCheckdigit.forEach((NumberCheckInput, index) => {
    debugger
    NumberCheckInput.addEventListener("change", () => {
        var NumberCheckvalue = $(".NumberCheck").eq(index).val();
        if (NumberCheckvalue.match(NIDRegexcheck) != true) {
            const ErrorMSG = document.createElement("p");
            ErrorMSG.className = "ErrorMsg";
            ErrorMSG.innerText = "Please Enter Valid NID";
            $(".NumberCheck").eq(index).after(ErrorMSG);
        }
    });
});