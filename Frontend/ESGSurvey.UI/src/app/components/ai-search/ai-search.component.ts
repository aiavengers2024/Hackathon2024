import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { SearchService } from '../../services/search.service';
import { IOpenAISearch } from '../../models/ISearch';


@Component({
  selector: 'app-ai-search',
  templateUrl: './ai-search.component.html',
  styleUrls: ['./ai-search.component.css']
})
export class AIOpenAISearchComponent  {
  Results: IOpenAISearch[] = [];
  searchText: any = '';
  content: any = '';
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  constructor(private ResultsService: SearchService) {
  }
 
  getAllSearchResult(searchText: string) {
    this.ResultsService.getAllAISearchResult(searchText).subscribe(responce => {
      if (responce === null && responce.content ==='' ) {
        this.Results = responce;
        this.content = "Please check your input search text.";
      }
      console.log(responce);
      this.Results = responce;
      this.content = responce.content;
    })

  }
}
