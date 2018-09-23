import { Component, OnInit, Inject } from '@angular/core';
import { Quote } from './QUOTE';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css']
})
export class QuotesComponent implements OnInit {

  quotes: Quote[];
  newQuote: Quote;
  randomQuote: Quote;

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) { }

  ngOnInit() {
    this.quotes = [] as Quote[];
    this.newQuote = new Quote();
    this.randomQuote = new Quote();
  }

  addQuote() {
    return this.http.post(this.baseUrl + "api/quotes", this.newQuote).subscribe(() => {
      this.quotes.push(this.newQuote);
      this.newQuote = new Quote();
    });
  }

  getRandomQuote() {
    return this.http.get(this.baseUrl + "api/quotes/random").subscribe((quote: Quote) => {
      this.randomQuote = quote;
    })
  }

  getQuotes() {
    return this.http.get(this.baseUrl + "api/quotes/random").subscribe((quotes: Quote[]) => {
      this.quotes = quotes;
    })
  }
}
