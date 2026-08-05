import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBoxComponent } from '../../components/search-box/search-box.component';
import { Produto } from '../../models/produto';
import { ProdutoService } from '../../services/produto.service';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.services';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    SearchBoxComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  produtos:Produto[]=[];

    constructor(
        private produtoService:ProdutoService,
        private authService: AuthService,
        private router: Router
    ){}

    logout(): void {
      const confirmar = confirm('Deseja realmente sair?');
      if(!confirmar){
        return;
      }
      this.authService.logout();
      this.router.navigate(['/login']);

}

    pesquisar(termo:string){

        this.produtoService
            .buscar(termo)
            .subscribe(res=>{

                this.produtos=res;

            });

    }
}
