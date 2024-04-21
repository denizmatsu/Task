$(document).ready(function () {
    $('#loading').show(); 
    var requestData = {
        url: '/Talepler/GetTalepler',
        method: 'GET',
        data: null,
        showNotification: true
    };

    var response = sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification)
        .then(function (response) {
            var talepler = response.data;
            var tableBody = $('#taleplerTable tbody');
            $.each(talepler, function (index, talep) {
                var row = '<tr>' +
                    '<td>' + talep.customerName + '</td>' +
                    '<td>' + talep.complaint + '</td>' +
                    '<td>' + talep.email + '</td>' +
                    '<td>' + talep.body + '</td>' +
                    '</tr>';
                tableBody.append(row);
            });

            $('#taleplerTable').show(); 
            $('#loading').hide(); 
            console.log(response);
        })
        .catch(function (error) {
            $('#loading').hide(); 
            console.error(error);
        });


    
});