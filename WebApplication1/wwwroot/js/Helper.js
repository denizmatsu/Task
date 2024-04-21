function showToast(messages) {
    var toastContainer = $('.toast-container');
    if (toastContainer.length === 0) {
        toastContainer = $('<div class="toast-container position-fixed bottom-0 end-0 p-3" style="z-index: 11; padding-bottom: 3px;"></div>');
        $('body').append(toastContainer);
    }

    messages.forEach(function (message, index) {
        var toast = $(
            '<div class="toast" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="true" data-delay="1000">' +
            '<div class="toast-header">' +
            '<strong class="mr-auto">Bilgi</strong>' +
            '<button type="button" class="btn-close" aria-label="Close" style="margin-left: auto;">' +
            '<span aria-hidden="true">&times;</span>' +
            '</button>' +
            '</div>' +
            '<div class="toast-body">' +
            '<p>' + message + '</p>' +
            '</div>' +
            '</div>'
        );

        toastContainer.append(toast);
        toast.toast('show');

        toast.find('.btn-close').click(function () {
            toast.toast('hide');
        });
    });
}


function sendRequest(url, method, data, showNotification) {
    return new Promise(function (resolve, reject) {
        $('#loading').show(); 
        data = data || {};

        $.ajax({
            url: url,
            method: method,
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (response) {
                $('#loading').hide(); 
                if (showNotification) {
                    if (response.succeeded) {
                        showToast(["İşlem Başarılı"]);
                    } else {
                        showToast(response.ErrorMessage);
                    }
                }
                resolve(response);
            },
            error: function (xhr, status, error) {
                $('#loading').hide();
                showToast(["İşlem Başarısız"]);
                reject(error);
            }
        });
    });
}
