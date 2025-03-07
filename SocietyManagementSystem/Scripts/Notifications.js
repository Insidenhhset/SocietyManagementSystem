// Toastr global settings
toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "preventDuplicates": true,
    "onclick": null,
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "show",
    "hideMethod": "hide"
};

// Success notification function
function showSuccessNotification(message) {
    toastr.success(message, 'Success');
}

// Error notification function
function showErrorNotification(message) {
    toastr.error(message, 'Error');
}
