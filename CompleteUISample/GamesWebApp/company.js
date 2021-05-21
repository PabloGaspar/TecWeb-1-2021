window.addEventListener('load', (event) => {
    var queryParams = window.location.search.split('?');
    var companyId= queryParams[1].split('=')[1];

    document.getElementById("companyId").textContent= companyId;
});