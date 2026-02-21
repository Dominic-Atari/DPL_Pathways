document.addEventListener("DOMContentLoaded", function () {
    const donateLink = document.getElementById("donate");
    if (donateLink) {
        donateLink.addEventListener("click", function (event) {
            event.preventDefault();
            showDonateModal();
        });
    }

    const donateMobileLink = document.getElementById("donateMobile");
    if (donateMobileLink) {
        donateMobileLink.addEventListener("click", function (event) {
            event.preventDefault();
            showDonateModal();
        });
    }
});
function showDonateModal() {
    // hide the entire page and show the modal
    var mainBodyContent = document.getElementById("mainBodyContent");
    if (mainBodyContent) {
        mainBodyContent.style.display = "none";
    }

    const existingModal = document.querySelector(".donateModal");
    if (existingModal) {
        return;
    }
    const modl = document.createElement("div");

    modl.classList.add("donateModal");
    modl.innerHTML = `
        <div class="donateModal-content">
            <span class="close-donateModal-button" id="closeButton">&times;</span>
            <h2>Donate 844********</h2>
            <h3>Your support helps us keep our flight tracking services free and accessible to everyone.</h3>
            <h4>Donate today and help us continue to provide accurate and up-to-date flight information for travelers worldwide.</h4>
        </div>
    `;
    modl.style.display = "block";
    document.body.appendChild(modl);

    const closeButton = modl.querySelector("#closeButton") as HTMLSpanElement | null;
    if (closeButton) {
        closeButton.addEventListener("click", function (event) {
            event.preventDefault();
            event.stopPropagation();
            modl.remove();
            if (mainBodyContent) {
                mainBodyContent.style.display = "flex";
            }
        });
    }
}
