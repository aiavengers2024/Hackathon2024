import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ISearch } from '../../models/ISearch';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { SearchService } from '../../services/search.service';


@Component({
  selector: 'app-search-list',
  templateUrl: './search-list.component.html',
  styleUrls: ['./search-list.component.css']
})
export class SearchListComponent implements  AfterViewInit {
  //displayedColumns: string[] = ['fileName', 'searchContent', 'highlightedText', 'People', 'filePath',
  //  'keyphrases'];
  displayedColumns: string[] = [  'searchContent', 'highlightedText'];
  Results: ISearch[] = [];
  searchText: any;
  dataSource = new MatTableDataSource<ISearch>(this.Results)

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  
  constructor(private ResultsService: SearchService) {
  }

  
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  getAllSearchResult(searchText: string){
    this.ResultsService.getAllSearchResult(searchText).subscribe(responce => {
      this.Results = responce;
      this.dataSource = new MatTableDataSource(this.Results);
    })

  }
}
