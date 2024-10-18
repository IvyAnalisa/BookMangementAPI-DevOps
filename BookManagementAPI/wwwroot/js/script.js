const apiUrl = "/api/books"; // Use relative URL for API

// Function to fetch and display books
function fetchBooks() {
    fetch(apiUrl)
        .then(response => response.json())
        .then(books => {
            const bookList = document.getElementById('bookList');
            bookList.innerHTML = ''; // Clear the existing list
            books.forEach(book => {
                // Create table row for each book
                const tr = document.createElement('tr');

                tr.innerHTML = `
                    <td>${book.id}</td>
                    <td>${book.title}</td>
                    <td>${book.author}</td>
                    <td>${book.description}</td>
                    <td>${new Date(book.publishedDate).toLocaleDateString()}</td>
                    <td>
                        <button onclick="populateUpdateForm(${book.id})">Update</button>
                        <button onclick="deleteBook(${book.id})">Delete</button>
                    </td>
                `;

                bookList.appendChild(tr);
            });
        })
        .catch(error => console.error('Error fetching books:', error));
}

// Add book event
document.getElementById('addBook').addEventListener('click', () => {
    const title = document.getElementById('title').value;
    const author = document.getElementById('author').value;
    const description = document.getElementById('description').value;
    const publishedDate = document.getElementById('publishedDate').value;

    const newBook = { title, author, description, publishedDate };

    fetch(apiUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newBook),
    })
        .then(response => response.json())
        .then(() => {
            fetchBooks(); // Refresh the book list
            // Clear input fields
            document.getElementById('title').value = '';
            document.getElementById('author').value = '';
            document.getElementById('description').value = '';
            document.getElementById('publishedDate').value = '';
        })
        .catch(error => console.error('Error adding book:', error));
});

// Function to populate update form with selected book's data
function populateUpdateForm(id) {
    fetch(`${apiUrl}/${id}`)
        .then(response => response.json())
        .then(book => {
            document.getElementById('updateId').value = book.id;
            document.getElementById('updateTitle').value = book.title;
            document.getElementById('updateAuthor').value = book.author;
            document.getElementById('updateDescription').value = book.description;
            document.getElementById('updatePublishedDate').value = book.publishedDate.split('T')[0];
        })
        .catch(error => console.error('Error fetching book:', error));
}

// Update book event
document.getElementById('updateBook').addEventListener('click', () => {
    const id = document.getElementById('updateId').value;
    const title = document.getElementById('updateTitle').value;
    const author = document.getElementById('updateAuthor').value;
    const description = document.getElementById('updateDescription').value;
    const publishedDate = document.getElementById('updatePublishedDate').value;

    const updatedBook = { title, author, description, publishedDate };

    fetch(`${apiUrl}/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedBook),
    })
        .then(() => {
            fetchBooks(); // Refresh the book list
            // Clear update form fields
            document.getElementById('updateId').value = '';
            document.getElementById('updateTitle').value = '';
            document.getElementById('updateAuthor').value = '';
            document.getElementById('updateDescription').value = '';
            document.getElementById('updatePublishedDate').value = '';
        })
        .catch(error => console.error('Error updating book:', error));
});

// Delete book function
function deleteBook(id) {
    fetch(`${apiUrl}/${id}`, {
        method: 'DELETE',
    })
        .then(() => {
            fetchBooks(); // Refresh the book list
        })
        .catch(error => console.error('Error deleting book:', error));
}

// Fetch books when the page loads
window.onload = fetchBooks;
