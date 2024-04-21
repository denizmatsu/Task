$(document).ready(function () {
    handleTaleplerRequest();
});
const showLoading = function () {
    $('#loading').show();
};

const hideLoading = function () {
    $('#loading').hide();
};

const showTaleplerTable = function () {
    $('#taleplerTable').show();
};

const populateTaleplerTable = function (talepler) {
    if ($('#taleplerTable').length) {
        let table = new DataTable('#taleplerTable', {
            responsive: true,
            searching: true,
            paging: true,
            lengthMenu: [5, 10, 30, 50],
            data: talepler,
            columns: [
                { data: 'customerName' },
                { data: 'complaint' },
                { data: 'email' },
                { data: 'body' }
            ]
        });
    }
};

const handleTaleplerRequest = async function () {
    try {
        showLoading();

        const requestData = {
            url: '/Talepler/GetTalepler',
            method: 'GET',
            data: null,
            showNotification: true
        };

        const response = await sendRequest(requestData.url, requestData.method, requestData.data, requestData.showNotification);
        var talepler = response.data;

        populateTaleplerTable(talepler);
        showTaleplerTable();
        hideLoading();
    } catch (error) {
        hideLoading();
        console.error(error);
    }
};


