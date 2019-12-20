using System.IO;
using System.Windows.Forms;

namespace FilesSearch
{
    /// <summary>
    /// Узел дерева, представляющий папку ФС
    /// </summary>
    public class DirectoryNode : TreeNode
    {
        // имя папки
        public new string Name { get => Path.GetFileName(FullName); }
        // полный путь
        public string FullName { get; set; }
        // кол-во файлов в данной папке
        public int FilesCount { get; set; }
        // кол-во подпапок в данной папке 
        public int DirsCount { get; set; }
        // папка пуста?
        public bool IsEmpty { get => (DirsCount + FilesCount) == 0; }
        // родительская папка
        public new DirectoryNode Parent { get; private set; }
        // корневая папка (у нее нет родителя)
        public bool IsRoot { get => Parent == null; }
        // у данной папки уже извлекались подпапки?
        public bool DirsEnumerated { get; set; }
        // папка добавлена в дерево?
        public bool IsAddedToTree { get; set; }

        // конструктор для добавления корневого узла
        public DirectoryNode(string path) : base(Path.GetFileName(path))
        {
            FullName = path;
        }
        // конструктор для добавления дочернего узла
        public DirectoryNode(string path, DirectoryNode parent) : this(path)
        {
            Parent = parent;
        }

        // строковое представление узла
        public override string ToString()
        {
            return $"Полный путь: {FullName},\nКорневой узел: {IsRoot},\nКол-во подпапок: {DirsCount}, Кол-во файлов: {FilesCount}";            
        }
    }
}
