window.interopFunctions = {
    focusElement: function (element) {
        element.focus();
    },
    clickElement: function (element) {
        element.click();
    },
    showModal: function (element) {
        bootstrap.Modal.getOrCreateInstance(element).show();
    },
    hideModal: function (element) {
        bootstrap.Modal.getOrCreateInstance(element).hide();
    }
}
window.hideModal = function (name) {
    var el = document.getElementById(name);
    bootstrap.Modal.getOrCreateInstance(el).hide();
}
window.showModal = function (name) {
    var el = document.getElementById(name);
    bootstrap.Modal.getOrCreateInstance(el).show();
}
window.pushState = function(dict) {
    let url = new URL(window.location.href);
    let params = new URLSearchParams(url.searchParams);
    for (const elem of Object.keys(dict))
    {
        if (dict[elem] == null)
            params.delete(elem)
        else
            params.set(elem, dict[elem])
    }
    url.search = params.toString();
    if ((history.state && history.state.url !== url.href) || window.location.href !== url.href)
        history.pushState(null, '', url.href);
};
window.pushUrl = function(url) {
    if ((history.state && history.state.url !== url) || window.location.href !== url)
        history.pushState(null, '', url);
};
window.getLocalTime = function(utc) {
    return new Date(utc).toLocaleString();
}
window.getUtcTime = function(local) {
    return new Date(local).toUTCString();
}

window.addTooltips = function() {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => bootstrap.Tooltip.getOrCreateInstance(tooltipTriggerEl));
}