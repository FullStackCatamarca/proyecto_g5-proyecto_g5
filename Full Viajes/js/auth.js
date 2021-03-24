const auth = firebase.auth();
const login = document.getElementById('loginModal');
const resgistrarse = document.getElementById('registroModal');
const logout = document.getElementById('logout');
const usuarioReg = document.querySelectorAll('.registrado');
const usuarioComun = document.querySelectorAll('.comun');

window.onload = function () {
    console.log('hola')
    auth.onAuthStateChanged((user) => {
        if (user) {
            // User is signed in, see docs for a list of available properties
            // https://firebase.google.com/docs/reference/js/firebase.User
            var uid = user.uid;
            console.log('Sesion activa')
            usuarioReg.forEach((link) => (link.style.display = "block"));
            usuarioComun.forEach((link) => (link.style.display = "none"));
        } else {
            // User is signed out
            // ...
            console.log('No ha iniciado sesión')
            usuarioReg.forEach((link) => (link.style.display = "none"));
            usuarioComun.forEach((link) => (link.style.display = "block"));
        }
    });
};

logout.addEventListener('click', (e) => {
    e.preventDefault();
    firebase.auth().signOut().then(() => {
        console.log("signup out");
    });
});

login.addEventListener('submit', e => {
    e.preventDefault();
    console.log('enviando')
    let email = document.getElementById('login-email').value;
    let password = document.getElementById('login-password').value;


    auth.signInWithEmailAndPassword(email, password)
        .then((user) => {
            // Signed in
            // ...
            console.log('logeado')
            document.getElementById('login-form').reset();
            $('#loginModal').modal('hide')
        })
        .catch((error) => {
            console.log(error)

            if (error.code == 'auth/user-not-found') {
                document.getElementById('errorLogin').innerHTML = 'No hay ningún registro de usuario que corresponda a este identificador. Es posible que se haya eliminado al usuario.';
            }
            else {
                document.getElementById('errorLogin').innerHTML = error.message;
            }


        });
})

resgistrarse.addEventListener('submit', e => {
    e.preventDefault();

    let email = document.getElementById('registro-email').value;
    let password = document.getElementById('registro-password').value;

    auth.createUserWithEmailAndPassword(email, password)
        .then((user) => {
            console.log(user.email + ' reg')
            document.getElementById('registro-form').reset();
            $('#registroModal').modal('hide')
        })
        .catch((error) => {
            var errorCode = error.code;
            var errorMessage = error.message;

            console.log(errorMessage)
            // ..
        });
})

