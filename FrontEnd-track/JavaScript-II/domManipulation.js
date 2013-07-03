var domManipulation = (function () {
    var BUFFER_LIMIT = 100;
    var buffer = document.createDocumentFragment();

    function addElement(element, parent) {
        parent.appendChild(element);
    }

    function removeElement(selector) {
        // Here only selector to be removed needed.
        // Parent as parameter is unnecessary.
        var element = document.querySelector(selector);
        var parent = element.parentNode;
        parent.removeChild(element);
    }

    function attachEvent(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener("click", eventHandler, false);
        }
    }

    function appendToBuffer(parent, element) {
        var container = document.querySelector(parent);
        buffer.appendChild(element);
        if (buffer.childNodes.length >= BUFFER_LIMIT) {
            container.appendChild(buffer);
            buffer = document.createDocumentFragment();
        }
    }

    return {
        addElement: addElement,
        removeElement: removeElement,
        attachEvent: attachEvent,
        appendToBuffer: appendToBuffer
    };
})();