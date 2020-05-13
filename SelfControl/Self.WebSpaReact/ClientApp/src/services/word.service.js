import authHeader from './auth-header';

class WordService {
    async getWords() {
        const requestOptions = {
            method: 'GET',
            headers: authHeader() 
        };

        const response = await fetch('word/get-words', requestOptions);
        const data = await response.json();

        return data;
    }
}

export default new WordService();