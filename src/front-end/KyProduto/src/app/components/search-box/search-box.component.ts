import { Component,EventEmitter, Output} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-box',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent {

  termo = '';

  recentes: string[] = [
    'Vestido',
    'Camiseta',
    'Tiara',
    'Biquini'
  ];

  @Output()

  buscarProduto = new EventEmitter<string>();


  buscar() {
    this.buscarProduto.emit(this.termo);
  }

  limpar() {
    this.termo = '';
  }

  selecionarRecente(item: string) {
  this.termo = item;
}

}
