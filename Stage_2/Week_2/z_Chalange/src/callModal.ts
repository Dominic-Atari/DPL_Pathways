document.addEventListener("DOMContentLoaded", function () {
    const callButton = document.getElementById("call");
    if (callButton) {
        callButton.addEventListener("click", function () {
            showCallModal();
        });
    }
});
function showCallModal() {
    // hide the entire page and show the modal
    // var mainBodyContent = document.getElementById("mainBodyContent");
    // if (mainBodyContent) {
    //     mainBodyContent.style.display = "none";
    // }

    const callButton = document.getElementById("call") as HTMLSpanElement;
    if (callButton) {
        const existingModal = document.querySelector(".callModal");
        if (existingModal) {
            return;
        }
        const modl = document.createElement("div");

        modl.classList.add("callModal");
        modl.innerHTML = `
            <div class="callModal-content">
                <span class="close-callModal-button" id="closeButton">&times;</span>
                <h2>Flight Contact</h2>
                <h3>Call us at DPL 844********</h3>
                <h4>Available 24/7 for your travel needs</h4>
            </div>
            <style>
                .callModal {
                    display: none;
                    position: fixed;
                    z-index: 1;
                    right: 10%;
                    top: 5%;
                    width: 100%;
                    height: 100%;
                    overflow: none;
                }

                .callModal-content {
                    background-color: #d3a9a9ff;
                    /* margin: 15% auto; */
                    position: absolute;
                    top: 17%;
                    left: 87.7%;
                    transform: translate(-50%, -50%);
                    padding: 20px;
                    border: 1px solid #888;
                    width: 20%;
                    border-radius: 10px;
                }

                .close-callModal-button {
                    color: #3b3b3e;
                    float: right;
                    font-size: 28px;
                    font-weight: bold;
                }

                .close-callModal-button:hover,
                .close-callModal-button:focus {
                    color: black;
                    text-decoration: none;
                    cursor: pointer;
                }
        `;
        modl.style.display = "block";
        document.body.appendChild(modl);

        const closeButton = modl.querySelector("#closeButton") as HTMLSpanElement | null;
        if (closeButton) {
            closeButton.addEventListener("click", function (event) {
                event.preventDefault();
                event.stopPropagation();
                modl.remove();
                // if (mainBodyContent) {
                //     mainBodyContent.style.display = "flex";
                // }
            });
        }
    }
}
