

document.addEventListener('DOMContentLoaded', () => {

    const options = document.querySelectorAll('.card select');
    const btns = document.querySelectorAll('#productContainer .btn');
   

    options.forEach((opt) => {
        let card = opt.closest('.card');
        let select = card.querySelector('select');
        const id = card.querySelector('.btn').id;
        //Deshabilitar el botón
        if (opt.value == "") {
            card.querySelector('.btn').style.pointerEvents = "none";
        }
        //Habilitar botón
        opt.addEventListener('change', () => {
            if (opt.value != "") {
                card.querySelector('.btn').className = "btn btn-danger";
                card.querySelector('.btn').removeAttribute("style");
                //Guardar cantidad (home)
                card.querySelector('.btn').id = select.value < 10 ? id + "-" + "0" + select.value : id + "-" + select.value;

            } else {
                card.querySelector('.btn').className = "btn btn-outline-danger";
                card.querySelector('.btn').style.pointerEvents = "none";
                //Quitar cantidad (home)
                card.querySelector('.btn').id = id;
            }
        });
    });

    if (document.querySelector('#Checkout')) {
        if (document.querySelector('#totalPrice').innerText == 0) {
            document.querySelector('#Checkout').classList.add('disabled');
        }
    }
    
})

