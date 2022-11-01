// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Query the table
const table = document.getElementById('sortMe');

// Query the headers
const headers = table.querySelectorAll('th');

// Loop over the headers
[].forEach.call(headers, function (header, index) {
    header.addEventListener('click', function () {
        // This function will sort the column
        sortColumn(index);
    });
});

// Query all rows
const tableBody = table.querySelector('tbody');
const rows = tableBody.querySelectorAll('tr');

const sortColumn = function (index) {
    // Get the current direction
    const direction = directions[index] || 'asc';

    // A factor based on the direction
    const multiplier = (direction === 'asc') ? 1 : -1;
    // Clone the rows
    const newRows = Array.from(rows);

    // Sort rows by the content of cells
    newRows.sort(function (rowA, rowB) {
        // Get the content of cells
        const cellA = rowA.querySelectorAll('td')[index].innerHTML;
        const cellB = rowB.querySelectorAll('td')[index].innerHTML;

        const a = transform(index, cellA);
        const b = transform(index, cellB);



        switch (true) {
            case a > b: return 1 * multiplier;
            case a < b: return -1 * multiplier;
            case a === b: return 0;
        }
    });

    directions[index] = direction === 'asc' ? 'desc' : 'asc';

    // Remove old rows
    [].forEach.call(rows, function (row) {
        tableBody.removeChild(row);
    });

    // Append new row
    newRows.forEach(function (newRow) {
        tableBody.appendChild(newRow);
    });
};

const transform = function (index, content) {
    // Get the data type of column
    const type = headers[index].getAttribute('data-type');
    switch (type) {
        case 'number':
            return parseFloat(content);
        case 'nosort':
            return;
        case 'text':
        default:
            return content;
    }
};

// Track sort directions
const directions = Array.from(headers).map(function (header) {
    return '';
});