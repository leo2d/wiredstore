const loadFile = (event, id) => {
    const output = document.getElementById(id);
    //document.createElement('img');
    output.src = URL.createObjectURL(event.target.files[0]);
    output.className = "img-register-preview";
};

