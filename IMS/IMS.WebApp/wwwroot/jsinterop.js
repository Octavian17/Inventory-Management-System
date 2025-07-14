function proventFormSubmission(formId) {
    document.getElementById(formId).addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            event.preventDefault();
            return false;
        }
    });
}