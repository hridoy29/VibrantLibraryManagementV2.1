function showhidePassword(textBoxId) {
    const textBox = document.getElementById(textBoxId);
    const icon = textBox.parentElement.querySelector('.e-input-group-icon');
    icon.classList.toggle('fa-eye');
    icon.classList.toggle('fa-eye-slash');
}