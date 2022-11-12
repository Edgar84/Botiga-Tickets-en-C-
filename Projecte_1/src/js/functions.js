document.addEventListener('DOMContentLoaded', () => {
    
    const options = document.querySelectorAll('.card select');
    options.forEach((opt) => {
        opt.addEventListener('change', () => {
            const card = opt.closest('.card');
            if (opt.value != "") {
                card.querySelector('button').className = "btn btn-danger";
            } else {
                card.querySelector('button').className = "btn btn-outline-danger";
            }
        });
    });
})



