import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { words: [], loading: true };
  }

  componentDidMount() {
    this.getWords();
  }

  static renderForecastsTable(words) {
    console.log(words);

    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Word</th>
            <th>Meaning</th>
            <th>Example</th>
          </tr>
        </thead>
        <tbody>
          {words.map(word =>
            <tr key={word.id}>
              <td>{word.originalWord}</td>
              <td>{word.englishMeaning}</td>
              <td>{word.sentence}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.words);

    return (
      <div>
        <h1 id="tabelLabel" >Sample Words</h1>
        {contents}
      </div>
    );
  }

  async getWords() {
    const response = await fetch('word/get-words');
    const data = await response.json();
    this.setState({ words: data, loading: false });
  }
}
