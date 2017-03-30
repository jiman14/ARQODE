using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace HelpControls
{
    public class CRellenarArbol
    {        

        /// <summary>
        /// Rellena un arbol desde el sistema de ficheros
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Omit_files_and_dir_list_by_name"></param>
        public TreeNode DesdeSistemaArchivos_recursivo(String path, String Omit_files_and_dir_list="")
        {
            return DesdeSistemaArchivos_recursivo(new DirectoryInfo(path), Omit_files_and_dir_list);
        }
        /// <summary>
        /// Rellena un arbol desde el sistema de ficheros
        /// </summary>
        /// <param name="di"></param>
        /// <param name="Omit_files_and_dir_list"></param>
        /// <returns></returns>
        public TreeNode DesdeSistemaArchivos_recursivo(DirectoryInfo di, String Omit_files_and_dir_list="")
        {

            if ((di != null) && (!Omit_files_and_dir_list.ToLower().Contains(di.Name.ToLower())))
            {
                //Nodo carpeta actual
                TreeNode tn_child = new TreeNode(di.Name);
                tn_child.Name = di.Name;

                // Añadir directorios hijos
                foreach (DirectoryInfo di_child in di.GetDirectories())
                {
                    if (!Omit_files_and_dir_list.ToLower().Contains(di_child.Name.ToLower()))
                    {
                        tn_child.Nodes.Add(DesdeSistemaArchivos_recursivo(di_child, Omit_files_and_dir_list));
                    }
                }

                // Añadir ficheros hijos
                foreach (FileInfo fi_child in di.GetFiles())
                {
                    if (!Omit_files_and_dir_list.ToLower().Contains(fi_child.Name.ToLower()))
                    {
                        tn_child.Nodes.Add(fi_child.Name);
                        tn_child.Nodes[tn_child.Nodes.Count-1].Name = fi_child.Name;
                    }
                }

                return tn_child;
            }
            else return null;
        }

        public List<TreeNode> CrearListaNodosHoja(TreeNode arbol_origen)
        {
            List<TreeNode> listaNodos = new List<TreeNode>();

            CrearListaNodosHojaRecursivo(arbol_origen, ref listaNodos);

            return listaNodos;
        }

        /// <summary>
        /// Crear lista de nodos hoja del árbol
        /// </summary>
        /// <param name="arbol_origen"></param>
        /// <param name="listaNodos"></param>
        private void CrearListaNodosHojaRecursivo(TreeNode arbol_origen, ref List<TreeNode> listaNodos)
        {
            if (arbol_origen.Nodes.Count > 0)
            {
                foreach (TreeNode child_node in arbol_origen.Nodes)
                {
                    CrearListaNodosHojaRecursivo(child_node, ref listaNodos);
                }
            }
            else
            {
                listaNodos.Add(arbol_origen);
            }
        }
    }
}
