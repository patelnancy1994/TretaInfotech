$("#btnGenerate").click(function () {
    var fileInput = document.getElementById("fileInput");
    if (fileInput.files.length === 0) {
        alert("Please select a CSV file first.");
        return;
    }
    var file = fileInput.files[0];
    var reader = new FileReader();

    reader.onload = function (e) {
        var lines = e.target.result.split(/\r?\n/);
        var addressees = [];

        for (var i = 1; i < lines.length; i++) {
            if (lines[i].trim() === "") continue;

            var values = lines[i].split(",");
            addressees.push({
                ContactPerson: values[0],
                StreetAddress: values[1],
                Suburb: values[2],
                State: values[3],
                PostCode: values[4],
                FirstName: values[5],
                CardNumber: values[6],
                ExpireDate: values[7]
            });
        }
        var apiUrl = document.getElementById("hid_ApiUrl").value;
        console.log(apiUrl);
        $.ajax({
            url: apiUrl + "/Letter/GenerateLetters",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ Addressees: addressees }),
            success: function (data) {
                downloadFile(data, "Letters.html");
            },
            error: function (xhr, status, error) {
                alert("Error generating letters: " + error);
            }
        });
    };
    reader.readAsText(file);
});

function downloadFile(generatedFileContent, generatedFileName)
{
    if (!generatedFileContent || !generatedFileName) {
        alert('No file available for download');
        return;
    }
    const blob = new Blob([generatedFileContent], { type: 'text/html' });

    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = generatedFileName.endsWith('.html') ? generatedFileName : `${generatedFileName}.html`;

    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);

    URL.revokeObjectURL(url);
}
