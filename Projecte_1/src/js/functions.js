

document.addEventListener('DOMContentLoaded', () => {

    const options = document.querySelectorAll('.card select');

    options.forEach((opt) => {
        let card = opt.closest('.card');
        let select = card.querySelector('select');
        let id = card.querySelector('.btn').id;
        //Deshabilitar el botó
        if (opt.value == "") {
            card.querySelector('.btn').style.pointerEvents = "none";
        }
        //Habilitar botó
        opt.addEventListener('change', () => {
            if (opt.value != "") {
                card.querySelector('.btn').className = "btn btn-danger";
                card.querySelector('.btn').removeAttribute("style");

            } else {
                card.querySelector('.btn').className = "btn btn-outline-danger";
                card.querySelector('.btn').style.pointerEvents = "none";
            }
        });
    });
    //Deshabilitar Realitzar comanda
    if (document.querySelector('#Checkout')) {
        if (document.querySelector('#totalPrice').innerText == 0) {
            document.querySelector('#Checkout').classList.add('disabled');
        }
    }
});

    


