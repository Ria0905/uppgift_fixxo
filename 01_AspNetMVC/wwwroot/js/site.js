﻿const toggleBtn = document.querySelector('[data-option="toggle"]')
toggleBtn.addEventListener('click', function () {
    const element = document.querySelector(toggleBtn.getAttribute('data-target'))

    if (!element.classList.contains('hide'))
        element.classList.add('hide')
    else 
        element.classList.remove('hide')
})


const textValidation = (target, minLength) => {
    if (target.value.length >= minLength) {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
    } else {
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = `must contain more then ${minLength} characters`
    }
}

const emailValidation = (target) => {
    const regEx = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!regEx.test(target.value))
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = `must be a valid email address`
    else
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""

}
const passwordValidation = (target) => {
    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/;

    if (!regEx.test(target.value))
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = `must be a valid password`
    else
        document.querySelector(`[data-valmsg-for="${target.id}"]`).innerHTML = ""
}


//const passwordConfirm = (passwordInput) => {
//    let passwordConfirmInput = document.querySelector("#password-confirm-input");

//    if (passwordConfirmInput.value === passwordInput.value)
//        document.querySelector("#password-confirm-label").innerHTML = ""
//    else
//        document.querySelector("#password-confirm-label").innerHTML = "Password doesn't match"
//}



const inputs = document.querySelectorAll(`[data-val-required]`)
for (let input of inputs)
    input.addEventListener('keyup', function (event) {
        switch (event.target.type) {
            case 'text':
                textValidation(event.target, 2)
                break

            case 'email':
                emailValidation(event.target)
                break

            case 'password':
                passwordValidation(event.target)
                
                break
        }
    })
