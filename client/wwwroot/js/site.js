// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Submit the form with the given id
function submitDeleteForm(id) {
    document.getElementById('deleteForm-' + id).submit();
}

function toggleEditForm() {
    // Select all elements with the class 'toggle-edit' and add an event listener
    document.querySelectorAll('.toggle-edit').forEach(icon => {
        icon.addEventListener('click', function () {
            const targetId = this.dataset.target;
            const inputField = document.querySelector(`[asp-for='${targetId}']`);

            if (inputField) {
                inputField.readOnly = !inputField.readOnly; // Toggle readonly
                if (!inputField.readOnly) {
                    inputField.classList.add('border-primary'); // Highlight editable field
                } else {
                    inputField.classList.remove('border-primary'); // Remove highlight
                }
            }
        });
    });
}
document.addEventListener('DOMContentLoaded', initializeFieldToggles);